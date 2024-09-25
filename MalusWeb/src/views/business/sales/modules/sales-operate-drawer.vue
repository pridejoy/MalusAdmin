<script setup lang="ts">
import { computed, reactive, ref, watch } from 'vue';
import { useNaiveForm } from '@/hooks/common/form';
import { addSales, upSales } from '@/service/api';
import type { BsSalesRes } from '@/types/res/BsSalesRes.ts';
defineOptions({
  name: 'SalesOperateDrawer'
});

interface Props {
  /** the type of operation */
  operateType: NaiveUI.TableOperateType;
  /** the edit row data */
  rowData?: BsSalesRes | null;
}

const props = defineProps<Props>();

interface Emits {
  (e: 'submitted'): void;
}

const emit = defineEmits<Emits>();

const visible = defineModel<boolean>('visible', {
  default: false
});

const { formRef, validate, restoreValidation } = useNaiveForm();

const title = computed(() => {
  const titles: Record<NaiveUI.TableOperateType, string> = {
    add: '新增销售',
    edit: '编辑销售'
  };
  return titles[props.operateType];
});

type Model = Pick<BsSalesRes | any, 'saleId' | 'saleName' | 'saleTel' | 'sort'>;

const model: Model = reactive(createDefaultModel());

function createDefaultModel(): Model {
  return {
    saleId: 0,
    saleName: '',
    saleTel: '',
    sort: 0
  };
}

function handleUpdateModelWhenEdit() {
  if (props.operateType === 'add') {
    Object.assign(model, createDefaultModel());
    return;
  }

  if (props.operateType === 'edit' && props.rowData) {
    Object.assign(model, props.rowData);
  }
}

function closeDrawer() {
  visible.value = false;
}

async function handleSubmit() {
  await validate();
  // request
  if (props.operateType === 'add') {
    // console.log('当前接收的数据', model);
    // console.log('提交表单', model);
    addSales(model).then(res => {
      // console.log('请求成功', res);
      if (res.data) {
        window.$message?.success('添加成功');
        closeDrawer();
        emit('submitted');
      }
    });
  }

  if (props.operateType === 'edit' && props.rowData) {
    upSales(model).then(res => {
      // console.log('修改返回的状态', res);
      if (res.data) {
        window.$message?.success($t('common.updateSuccess'));
        closeDrawer();
        emit('submitted');
      } else {
        window.$message?.error('修改失败');
      }
    });
  }
  // request
  console.log('提交的model', model);
}

watch(visible, () => {
  if (visible.value) {
    handleUpdateModelWhenEdit();
    restoreValidation();
  }
});
</script>

<template>
  <NDrawer v-model:show="visible" :title="title" display-directive="show" :width="360">
    <NDrawerContent :title="title" :native-scrollbar="false" closable>
      <NForm ref="formRef" :model="model">
        <NFormItem label="销售名称" path="saleName">
          <NInput v-model:value="model.saleName" :disabled="model.configID > 0" placeholder="请输入销售名称" />
        </NFormItem>
        <NFormItem label="销售电话" path="saleTel">
          <NInput v-model:value="model.saleTel" placeholder="请输入销售电话" />
        </NFormItem>
        <NFormItem label="排序" path="saleTel">
          <NInputNumber v-model:value="model.sort" :placeholder="$t('page.manage.menu.form.order')" />
        </NFormItem>
      </NForm>
      <template #footer>
        <NSpace :size="16">
          <NButton @click="closeDrawer">{{ $t('common.cancel') }}</NButton>
          <NButton type="primary" @click="handleSubmit">{{ $t('common.confirm') }}</NButton>
        </NSpace>
      </template>
    </NDrawerContent>
  </NDrawer>
</template>

<style scoped></style>
