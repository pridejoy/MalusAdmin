<script setup lang="tsx">
import { NButton } from 'naive-ui';
import { getSyslogPage } from '@/service/api';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import { useTable, useTableOperate } from '@/hooks/common/table';

const appStore = useAppStore();

const { columns, data, getData, loading, mobilePagination } = useTable({
  apiFn: getSyslogPage,
  apiParams: {
    pageNo: 1,
    pageSize: 10,
    // if you want to use the searchParams in Form, you need to define the following properties, and the value is null
    // the value can not be undefined, otherwise the property in Form will not be reactive
    status: null
    // nickName: null,
    // userPhone: null,
    // userEmail: null
  },
  columns: () => [
    {
      key: 'account',
      title: '用户名',
      align: 'center',
      minWidth: 50
    },
    {
      key: 'reqMethod',
      title: '请求方式',
      align: 'center',
      width: 70
    },
    {
      key: 'url',
      title: '请求地址',
      align: 'center',
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'ip',
      title: 'Ip',
      align: 'center',
      minWidth: 100
    },
    {
      key: 'os',
      title: '系统',
      align: 'center',
      minWidth: 100
    },
    {
      key: 'browser',
      title: '浏览器',
      align: 'center',
      minWidth: 100
    },
    {
      key: 'elapsedTime',
      title: '耗时',
      align: 'center',
      minWidth: 30
    },
    {
      key: 'result',
      title: '响应',
      align: 'center',
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'opTime',
      title: '请求时间',
      align: 'center',
      minWidth: 100
    },
    // {
    //   key: 'email',
    //   title: '详情',
    //   align: 'center',
    //   minWidth: 200
    // },

    {
      key: 'operate',
      title: $t('common.operate'),
      align: 'center',
      width: 130,
      render: row => (
        <div class="flex-center gap-8px">
          <NButton type="primary" ghost size="small" onClick={() => edit(row.id)}>
            详情
          </NButton>
        </div>
      )
    }
  ]
});

const {
  // drawerVisible,
  // operateType,
  // editingData,
  // handleAdd,
  handleEdit,
  checkedRowKeys
  // onBatchDeleted
  // onDeleted
  // closeDrawer
} = useTableOperate(data, getData);

function edit(id: number) {
  handleEdit(id);
}
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NCard title="日志列表" :bordered="false" size="small" class="sm:flex-1-hidden card-wrapper">
      <template #header-extra>
        <NButton size="small" @click="refresh">
          <template #icon>
            <icon-mdi-refresh class="text-icon" :class="{ 'animate-spin': loading }" />
          </template>
          刷新
        </NButton>
      </template>
      <NDataTable
        v-model:checked-row-keys="checkedRowKeys"
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
  </div>
</template>

<style scoped></style>
