<script setup lang="tsx">
import { NButton, NPopconfirm } from 'naive-ui';
import { onMounted, ref } from 'vue';
import { deleteSales, getSalesPage } from '@/service/api';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import { useTable, useTableOperate } from '@/hooks/common/table';
import type { BsSalesRes } from '@/types/res/BsSalesRes.ts';
import SalesOperateDrawer from './modules/sales-operate-drawer.vue';
const appStore = useAppStore();

const { data, getData, columns, loading, pagination, mobilePagination } = useTable({
  apiFn: getSalesPage,
  apiParams: {
    pageNo: 1,
    pageSize: 10
  },
  columns: () => [
    {
      key: 'saleId',
      title: '序号',
      align: 'center',
      width: 50,
      minWidth: 100
    },
    {
      key: 'saleName',
      title: '销售名称',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'saleTel',
      title: '销售电话',
      align: 'center',
      width: 100,
      minWidth: 200
    },
    {
      key: 'sort',
      title: '销售排序',
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
            {$t('common.edit')}
          </NButton>
          <NPopconfirm onPositiveClick={() => handleDelete(row.configID)}>
            {{
              default: () => $t('common.confirmDelete'),
              trigger: () => (
                <NButton type="error" ghost size="small">
                  {$t('common.delete')}
                </NButton>
              )
            }}
          </NPopconfirm>
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

function handleDelete(id: number) {
  // request
  // console.log(id);
  deleteSales(id).then(res => {
    if (res.data) {
      window.$message?.success('删除成功');
      getData();
    } else {
      window.$message?.success('删除成功');
    }
  });
}

onMounted(async () => {
  try {
    // console.log('res');
  } catch (error) {
    console.error('Failed to fetch system data:', error);
    // 可以在这里添加更多的错误处理逻辑
  }
});
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NCard title="销售管理" :bordered="false" size="small" class="sm:flex-1-hidden card-wrapper">
      <template #header-extra>
        <TableHeaderOperation :loading="loading" :is-hidden="true" @add="handleAdd" @refresh="getData" />
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
      <SalesOperateDrawer
        v-model:visible="drawerVisible"
        :operate-type="operateType"
        :row-data="editingData"
        @submitted="getData"
      ></SalesOperateDrawer>
    </div>
  </div>
</template>

<style scoped></style>
