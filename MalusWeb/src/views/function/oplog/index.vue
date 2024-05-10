<script setup lang="tsx">
import { onMounted, reactive, ref } from 'vue';
import type { TableColumn } from 'naive-ui';
import { NButton, NPopconfirm, NTag, useMessage } from 'naive-ui';
import { getSyslogPage } from '@/service/api';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
// 抽屉开关
const active = ref(false);

// 开关抽屉的方法
const activate = () => {
  active.value = true;
};

// 刷新的方法
const refresh = () => {};

const appStore = useAppStore();

// const columns = [
//   {
//     key: 'account',
//     title: '用户名',
//     align: 'center',
//     minWidth: 50
//   },
//   {
//     key: 'reqMethod',
//     title: '请求方式',
//     align: 'center',
//     width: 70
//   },
//   {
//     key: 'url',
//     title: '请求地址',
//     align: 'center',
//     Width: 200,
//     ellipsis: {
//       tooltip: true
//     }
//   },
//   {
//     key: 'ip',
//     title: 'Ip',
//     align: 'center',
//     minWidth: 100
//   },
//   {
//     key: 'os',
//     title: '系统',
//     align: 'center',
//     minWidth: 100
//   },
//   {
//     key: 'browser',
//     title: '浏览器',
//     align: 'center',
//     minWidth: 100
//   },
//   {
//     key: 'elapsedTime',
//     title: '耗时',
//     align: 'center',
//     minWidth: 30
//   },

//   {
//     key: 'opTime',
//     title: '请求时间',
//     align: 'center',
//     minWidth: 100
//   },
//   {
//     key: 'operate',
//     title: $t('common.operate'),
//     align: 'center',
//     width: 130
//   }
// ];

const columns: TableColumn<any>[] = [
  {
    title: 'Name',
    key: 'name'
  },
  {
    title: 'Age',
    key: 'age'
  },
  {
    title: 'Address',
    key: 'address'
  },
  {
    key: 'operate',
    title: '操作',
    align: 'center',
    width: 130,
    render: row => (
      <NButton></NButton>
      // <div class="flex-center gap-8px">
      //   <NButton type="primary" ghost size="small" onClick={() => edit(row.id)}>
      //     {$t('common.edit')}
      //   </NButton>
      // </div>
    )
  }
];

const message = useMessage();
const play = (row: any) => {
  message.info(`Play ${row.title}`);
};

const pageParams = reactive({
  pageNo: 1,
  pageSize: 10
});

const pagination: PaginationProps = reactive({
  page: 1,
  pageSize: 10,
  showSizePicker: true,
  pageSizes: [10, 15, 20, 25, 30],
  onUpdatePage: async (page: number) => {
    pagination.page = page;
  },
  onUpdatePageSize: async (pageSize: number) => {
    pagination.pageSize = pageSize;
    pagination.page = 1;
  }
});

const data = ref<sysLogPageRecord[] | null>();

onMounted(async () => {
  try {
    data.value = (await getSyslogPage({ PageNo: pagination.page, PageSize: pagination.pageSize })).data?.records;
    console.log('res', data.value);
  } catch (error) {
    console.error('Failed to fetch system data:', error);
    // 可以在这里添加更多的错误处理逻辑
  }
});
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
      <NDataTable :columns="columns" :data="data" :pagination="pagination" />
      <!--
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
-->
    </NCard>
    <div>
      <NButtonGroup>
        <NButton @click="activate">打开</NButton>
      </NButtonGroup>
      <NDrawer v-model:show="active" :width="502">
        <NDrawerContent>
          <template #header>日志详情</template>
          <!--
 <template #footer>
        <n-button>Footer</n-button>
      </template>
-->
        </NDrawerContent>
      </NDrawer>
    </div>
  </div>
</template>

<style scoped></style>
