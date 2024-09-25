<script setup lang="tsx">
import { onMounted, reactive, ref, watch } from 'vue';
// import useHookTable from '@sa/hooks';
import { deleteAppmentDate, getAppmentTimePage } from '@/service/api';
import { useTable, useTableOperate } from '@/hooks/common/table';
import { useAppStore } from '@/store/modules/app';
defineOptions({
  name: 'TimeDetail'
});

const appStore = useAppStore();

// 打开关闭
const visible = defineModel<boolean>('visible', {
  default: false
});

interface Props {
  /** the edit row data */
  rowData?: any;
}

const props = defineProps<Props>();

const title = ref('');

const { data, getData, columns, loading, mobilePagination, searchParams, resetSearchParams } = useTable({
  apiFn: getAppmentTimePage,
  apiParams: {
    pageNo: 1,
    pageSize: 10,
    appointMentsDataId: 0
  },
  columns: () => [
    {
      key: 'appointMentsTimeId',
      title: '序号',
      align: 'center',
      width: 50,
      minWidth: 100
    },
    {
      key: 'startTime',
      title: '开始时间',
      align: 'center',
      width: 100,
      minWidth: 200,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'endTime',
      title: '结束时间',
      align: 'center',
      width: 100,
      minWidth: 200
      // render: row => {
      //   const date = new Date(row.appointMentsDate);

      //   // 使用 toLocaleDateString 方法格式化日期
      //   // 这里 'zh-CN' 是语言环境，'{year}/{month}/{day}' 是日期格式
      //   const formattedDate = date.toLocaleDateString('zh-CN', {
      //     year: 'numeric', // 年份
      //     month: '2-digit', // 月份，两位数字
      //     day: '2-digit' // 日期，两位数字
      //   });

      //   return `${formattedDate}`;
      // }
    },
    {
      key: 'appointMentsNum',
      title: '目标人数',
      align: 'center',
      width: 50,
      minWidth: 100,
      ellipsis: {
        tooltip: true
      }
    },
    {
      key: 'remainingPeople',
      title: '剩余人数',
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
      title: '操作',
      align: 'center',
      width: 100
      // render: row => (
      //   <div class="flex-center gap-8px">
      //     <NButton type="primary" ghost size="small" onClick={() => edit(row)}>
      //       详情
      //     </NButton>
      //     <NPopconfirm onPositiveClick={() => handleDelete(row.appointMentsDataId)}>
      //       {{
      //         default: () => $t('common.confirmDelete'),
      //         trigger: () => (
      //           <NButton type="error" ghost size="small">
      //             {$t('common.delete')}
      //           </NButton>
      //         )
      //       }}
      //     </NPopconfirm>
      //   </div>
      // )
    }
  ]
});

watch(visible, () => {
  title.value = props.rowData.appointMentsName;
  // 加载数据
  searchParams.appointMentsDataId = props.rowData.appointMentsDataId;
  getData();

  if (visible.value) {
    // handleUpdateModelWhenEdit();
    // restoreValidation();
  }
});
</script>

<template>
  <NModal v-model:show="visible">
    <NCard style="width: 80%; top: 30%" :title="title" :bordered="false" size="huge" role="dialog" aria-modal="true">
      <NDataTable
        :columns="columns"
        :data="data"
        size="small"
        :scroll-x="962"
        :loading="loading"
        remote
        :row-key="row => row.id"
        :pagination="mobilePagination"
        class="sm:h-full"
      />
    </NCard>
  </NModal>
</template>

<style scoped></style>
