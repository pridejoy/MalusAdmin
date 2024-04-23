<script setup lang="ts">
import { computed, shallowRef, watch } from 'vue';
import { $t } from '@/locales';
import { addUserButtonPermiss, getRoleButen, getSysRoleAllPermission } from '@/service/api';

defineOptions({
  name: 'ButtonAuthModal'
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

const title = computed(() => $t('common.edit') + $t('page.manage.role.buttonAuth'));

const tree = shallowRef<ResRolePermission[] | null>([]);

async function getAllButtons() {
  // request
  getSysRoleAllPermission().then(res => {
    tree.value = res.data;
    console.log('全部的按钮权限', tree.value);
  });
}

// 用户勾选的值
const checks = shallowRef<string[]>([]);

async function getuseButtons() {
  getRoleButen({ RoleId: props.roleId }).then(res => {
    checks.value = res.data !== null ? res.data.map(x => x.userPermiss) : [];
    console.log('用户勾选的值', checks.value);
  });
}

function handleSubmit() {
  addUserButtonPermiss({ roleId: props.roleId, permissionId: checks.value }).then(res => {
    if (res.data) {
      window.$message?.success('修改成功');
      closeModal();
    }
  });
}

function init() {
  getAllButtons();
  getuseButtons();
}

watch(visible, val => {
  if (val) {
    init();
  }
});
</script>

<template>
  <NModal v-model:show="visible" :title="title" preset="card" class="w-480px">
    <NTree
      v-model:checked-keys="checks"
      :data="tree"
      key-field="permissionId"
      label-field="permissionName"
      block-line
      checkable
      expand-on-click
      virtual-scroll
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
