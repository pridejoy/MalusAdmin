<script setup lang="tsx">
import { NButton, NPopconfirm } from 'naive-ui';
import { onMounted, ref } from 'vue';
import { deleteAppmentDate, getAppmentDatePage } from '@/service/api';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import { useTable, useTableOperate } from '@/hooks/common/table';
// import type { BsWechatConfigRes } from '@/typings/res/wechatconfig';
import DateOperateDrawer from './modules/date-operate-drawer.vue';
import TimeDetail from './modules/time-detail.vue';
const appStore = useAppStore();

const { data, getData, columns, loading, pagination, mobilePagination } = useTable({
  apiFn: getAppmentDatePage,
  apiParams: {
    pageNo: 1,
    pageSize: 10
  },
  columns: () => [
    {
      key: 'appointMentsDataId',
      title: '序号',
      align: 'center',
      width: 50,
      minWidth: 100
    },
    {
      key: 'appointMentsName',
      title: '名称',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'appointMentsDate',
      title: '预约日期',
      align: 'center',
      width: 100,
      minWidth: 200,
      render: row => {
        const date = new Date(row.appointMentsDate);

        // 使用 toLocaleDateString 方法格式化日期
        // 这里 'zh-CN' 是语言环境，'{year}/{month}/{day}' 是日期格式
        const formattedDate = date.toLocaleDateString('zh-CN', {
          year: 'numeric', // 年份
          month: '2-digit', // 月份，两位数字
          day: '2-digit' // 日期，两位数字
        });

        return `${formattedDate}`;
      }
    },
    {
      key: 'totalSlots',
      title: '总预约',
      align: 'center',
      width: 50,
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'unbookedPeople',
      title: '已预约',
      align: 'center',
      width: 50,
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'remainingSlots',
      title: '可预约',
      align: 'center',
      width: 50,
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'operate',
      title: $t('common.operate'),
      align: 'center',
      width: 100,
      render: row => (
        <div class="flex-center gap-8px">
          <NButton type="primary" ghost size="small" onClick={() => edit(row)}>
            详情
          </NButton>
          <NPopconfirm onPositiveClick={() => handleDelete(row.appointMentsDataId)}>
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

const showTimeModal = ref(false);
const timeData = ref(null);

const {
  drawerVisible,
  handleAdd,
  editingData,
  handleEditData,
  operateType
  // closeDrawer
} = useTableOperate(data, getData);

function edit(rowData: any) {
  showTimeModal.value = !showTimeModal.value;
  timeData.value = rowData;
  console.log(timeData.value);
}

function handleDelete(id: number) {
  // console.log(id);
  deleteAppmentDate(id).then(res => {
    if (res.data) {
      window.$message?.success('删除成功');
      getData();
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
    <NCard title="日期管理" :bordered="false" size="small" class="sm:flex-1-hidden card-wrapper">
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
      <TimeDetail v-model:visible="showTimeModal" :row-data="timeData"></TimeDetail>
      <!--
 <NModal v-model:show="showModal">
        <NCard
          style="width: 80%; top: 30%"
          title="预约详情"
          :bordered="false"
          size="huge"
          role="dialog"
          aria-modal="true"
        >
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
      </NModal>
-->

      <DateOperateDrawer
        v-model:visible="drawerVisible"
        :operate-type="operateType"
        @submitted="getData"
      ></DateOperateDrawer>
    </div>
  </div>
</template>

<style scoped></style>
