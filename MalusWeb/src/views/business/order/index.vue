<script setup lang="tsx">
import { NButton } from 'naive-ui';
import { getOrderPage } from '@/service/api';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import { useTable, useTableOperate } from '@/hooks/common/table';
// import type { BsCustomerRes } from '@/typings/res/customer_res';
import OrderOperateDrawer from './modules/order-operate-drawer.vue';
const appStore = useAppStore();

const { data, getData, columns, loading, mobilePagination } = useTable({
  apiFn: getOrderPage,
  apiParams: {
    pageNo: 1,
    pageSize: 10
  },
  columns: () => [
    {
      key: 'orderID',
      title: '序号',
      align: 'center',
      width: 50,
      minWidth: 100
    },
    {
      key: 'mobilePhone',
      title: '客户手机号',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'realName',
      title: '客户姓名',
      align: 'center',
      width: 100,
      minWidth: 200
    },
    {
      key: 'orderStatusStr',
      title: '状态',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'createdDate',
      title: '预约时间',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'operate',
      title: $t('common.operate'),
      align: 'center',
      width: 130,
      render: row => (
        <div class="flex-center gap-8px">
          <NButton type="primary" ghost size="small" onClick={() => edit(row)}>
            详情
          </NButton>
        </div>
      )
    }
  ]
});

const {
  drawerVisible,
  handleAdd,
  editingData,
  handleEditData,
  operateType
  // closeDrawer
} = useTableOperate(data, getData);

function edit(rowData: any) {
  handleEditData(rowData);
}
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NCard title="客户列表" :bordered="false" size="small" class="sm:flex-1-hidden card-wrapper">
      <template #header-extra>
        <TableHeaderOperation
          :loading="loading"
          :disabled-add="true"
          :is-hidden="true"
          @add="handleAdd"
          @refresh="getData"
        />
      </template>
      <NDataTable
        :columns="columns"
        :data="data"
        size="small"
        :flex-height="!appStore.isMobile"
        :scroll-x="962"
        :loading="loading"
        remote
        :row-key="row => row.id"
        :pagination="mobilePagination"
        class="sm:h-full"
      />
    </NCard>
    <div>
      <OrderOperateDrawer
        v-model:visible="drawerVisible"
        :operate-type="operateType"
        :row-data="editingData"
        @submitted="getData"
      ></OrderOperateDrawer>
    </div>
  </div>
</template>

<style scoped></style>
