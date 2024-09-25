<script setup lang="ts">
import { reactive, ref, watch } from 'vue';
import { useNaiveForm } from '@/hooks/common/form';
import { addAppmentDate } from '@/service/api';
defineOptions({
  name: 'DateOperateDrawer'
});

interface Props {
  /** the type of operation */
  operateType: NaiveUI.TableOperateType;
}

const props = defineProps<Props>();

interface Emits {
  (e: 'submitted'): void;
}

const emit = defineEmits<Emits>();

const visible = defineModel<boolean>('visible', {
  default: false
});

const { formRef, validate } = useNaiveForm();

const title = ref('新增预约日期');

type Model = Pick<any, 'appointMentsDate' | 'appointMentsDateStr'>;

const model: Model = reactive(createDefaultModel());

function createDefaultModel(): Model {
  return {
    appointMentsDate: '',
    appointMentsDateStr: null
  };
}

function handleUpdateModelWhenEdit() {
  if (props.operateType === 'add') {
    Object.assign(model, createDefaultModel());
  }
}

function closeDrawer() {
  visible.value = false;
}

async function handleSubmit() {
  await validate();
  // request
  if (props.operateType === 'add') {
    if (model.appointMentsDateStr) {
      // 将时间戳转换为Date对象
      const dateObject = new Date(model.appointMentsDateStr);
      // 将Date对象转换为ISO 8601格式的字符串
      model.appointMentsDate = dateObject.toLocaleString('zh-CN', { timeZone: 'Asia/Shanghai' });
    }
    addAppmentDate(model).then(res => {
      if (res.data) {
        window.$message?.success('添加成功');
        closeDrawer();
        emit('submitted');
      }
    });
  }

  // request
  console.log('提交的model', model);
}

watch(visible, () => {
  console.log('watch-visible', visible);
  if (visible.value) {
    handleUpdateModelWhenEdit();
    // restoreValidation();
  }
});
</script>

<template>
  <NDrawer v-model:show="visible" :title="title" display-directive="show" :width="360">
    <NDrawerContent :title="title" :native-scrollbar="false" closable>
      <NForm ref="formRef" :model="model">
        <NFormItem label="选择日期" path="configKey">
          <NDatePicker v-model:value="model.appointMentsDateStr" type="date" format="yyyy-MM-dd" />
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
