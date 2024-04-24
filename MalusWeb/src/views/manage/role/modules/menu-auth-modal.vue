<script setup lang="ts">
import { computed, shallowRef, watch } from 'vue';
import { $t } from '@/locales';
import { fetchGetAllPages, getMenuTreeList, getRoleUserMenu, setRoleUserMenu } from '@/service/api';

defineOptions({
  name: 'MenuAuthModal'
});

interface Props {
  /** the roleId */
  roleId: number;
}

const props = defineProps<Props>();

const visible = defineModel<boolean>('visible', {
  default: false
});

function closeModal() {
  visible.value = false;
}

const title = computed(() => $t('common.edit') + $t('page.manage.role.menuAuth'));

const home = shallowRef('');

async function getHome() {
  console.log(props.roleId);

  home.value = 'home';
}

async function updateHome(val: string) {
  // request

  home.value = val;
}

const pages = shallowRef<string[]>([]);

async function getPages() {
  const { error, data } = await fetchGetAllPages();

  if (!error) {
    pages.value = data;
  }
}

const pageSelectOptions = computed(() => {
  const opts: CommonType.Option[] = pages.value.map(page => ({
    label: page,
    value: page
  }));

  return opts;
});

const tree = shallowRef<Api.SystemManage.Menu[]>([]);

async function getTree() {
  await getMenuTreeList().then(res => {
    if (res.data?.records) {
      tree.value = res.data.records;
    }
  });
  console.log('tree', tree);
}

const checks = shallowRef<number[]>([]);

async function getChecks() {
  // request
  await getRoleUserMenu({ roleId: props.roleId }).then(res => {
    if (res.data) {
      checks.value = res.data;
      // console.log('checks', checks.value, res);
    }
  });
}

function handleSubmit() {
  console.log(checks.value, props.roleId);
  // request
  setRoleUserMenu({ roleId: props.roleId, menuId: checks.value }).then(res => {
    if (res.data) {
      window.$message?.success?.($t('common.modifySuccess'));

      closeModal();
      // console.log('checks', checks.value, res);
    }
  });
}

function init() {
  getTree();
  // getPages();
  getChecks();
}

watch(visible, val => {
  if (val) {
    init();
  }
});
</script>

<template>
  <NModal v-model:show="visible" :title="title" preset="card" class="w-480px">
    <!--
 <div class="flex-y-center gap-16px pb-12px">
      <div>{{ $t('page.manage.menu.home') }}</div>
      <NSelect :value="home" :options="pageSelectOptions" size="small" class="w-160px" @update:value="updateHome" />
    </div>
-->
    <NTree
      v-model:checked-keys="checks"
      :data="tree"
      key-field="id"
      label-field="menuName"
      checkable
      expand-on-click
      virtual-scroll
      block-line
      class="h-280px"
    />
    <template #footer>
      <NSpace justify="end">
        <NButton size="small" class="mt-16px" @click="closeModal">
          {{ $t('common.cancel') }}
        </NButton>
        <NButton type="primary" size="small" class="mt-16px" @click="handleSubmit">
          {{ $t('common.confirm') }}
        </NButton>
      </NSpace>
    </template>
  </NModal>
</template>

<style scoped></style>
