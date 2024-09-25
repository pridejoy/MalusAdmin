<script setup lang="ts">
import { computed, reactive, ref, watch } from 'vue';
import { useNaiveForm } from '@/hooks/common/form';
import { getOrderInfo } from '@/service/api';
import type { OrderInfoRes } from '@/typings/res/orderinfo_res';
import type { OrderRes } from '@/typings/res/order_res';
defineOptions({
  name: 'OrderOperateDrawer'
});

interface Props {
  /** the type of operation */
  operateType: NaiveUI.TableOperateType;
  /** the edit row data */
  rowData?: OrderRes | null;
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
    add: '客户资料',
    edit: '客户资料'
  };
  return titles[props.operateType];
});

const pagination = false as const;

const subcolumns = [
  {
    title: '订购人姓名',
    key: 'subscriberName'
  },
  {
    title: '手机号',
    key: 'subscriberMobile'
  },
  {
    title: '证件号码',
    key: 'subscriberIdCard'
  }
];

type Model = Pick<OrderInfoRes | any>;

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
    // 请求订单的详情
    getOrderInfo(props.rowData.orderID).then(res => {
      Object.assign(model, res.data);
    });
  }
}

function closeDrawer() {
  visible.value = false;
}

async function handleSubmit() {
  await validate();
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
  <NDrawer v-model:show="visible" :title="title" display-directive="show" width="75%">
    <NDrawerContent :title="title" :native-scrollbar="false" closable>
      <NDescriptions label-placement="left" title="基础信息">
        <NDescriptionsItem label="电话号码">{{ model.customer?.mobilePhone }}</NDescriptionsItem>
        <NDescriptionsItem label="姓名">{{ model.customer?.realName }}</NDescriptionsItem>
        <NDescriptionsItem label="注册时间">{{ model.customer?.createdDate }}</NDescriptionsItem>
        <NDescriptionsItem label="销售电话">{{ model.sales?.saleName }}</NDescriptionsItem>
        <NDescriptionsItem label="销售姓名">{{ model.sales?.saleTel }}</NDescriptionsItem>
      </NDescriptions>
      <br />
      <NTabs type="line" animated>
        <NTabPane name="oasis" tab="认购人信息">
          <NDataTable :columns="subcolumns" :data="model.subScriber" :pagination="pagination" :bordered="false" />
        </NTabPane>
        <NTabPane name="oasis1" tab="问答信息">
          <span v-for="(item, index) in model.answer" :key="index">
            <NTag type="success">{{ item.description }}:</NTag>
            {{ item.answers }}
          </span>
        </NTabPane>
        <NTabPane name="the beatles" tab="上传的资料"></NTabPane>
        <NTabPane name="jay chou" tab="状态变更历史">
          <NTimeline>
            <NTimelineItem
              v-for="(item, index) in model.history"
              :key="index"
              type="success"
              :title="item.describe"
              content=""
              :time="item.createdTime"
            ></NTimelineItem>
          </NTimeline>
        </NTabPane>
      </NTabs>
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
