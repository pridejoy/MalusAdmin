<script setup lang="ts">
import { computed, ref } from 'vue';
import { useLoading } from '@sa/hooks';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import { useAuthStore } from '@/store/modules/auth';
import { useAuth } from '@/hooks/business/auth';

const appStore = useAppStore();
const authStore = useAuthStore();
const { hasAuth } = useAuth();
const { loading, startLoading, endLoading } = useLoading();

type AccountKey = 'super' | 'admin' | 'user';

interface Account {
  key: AccountKey;
  label: string;
  userName: string;
  password: string;
}

const accounts = computed<Account[]>(() => [
  {
    key: 'super',
    label: $t('page.login.pwdLogin.superAdmin'),
    userName: 'Super',
    password: '123456'
  },
  {
    key: 'admin',
    label: $t('page.login.pwdLogin.admin'),
    userName: 'Admin',
    password: '123456'
  },
  {
    key: 'user',
    label: $t('page.login.pwdLogin.user'),
    userName: 'User',
    password: '123456'
  }
]);

const loginAccount = ref<AccountKey>('super');

async function handleToggleAccount(account: Account) {
  loginAccount.value = account.key;

  startLoading();
  await authStore.login(account.userName, account.password, false);
  endLoading();
  appStore.reloadPage();
}
</script>

<template>
  <NSpace vertical :size="16">
    <NCard title="权限校验" :bordered="false" size="small" segmented class="card-wrapper">
      <NDescriptions bordered :column="1">
        <NDescriptionsItem :label="$t('page.manage.user.userRole')">
          <NSpace>
            <NTag v-for="role in authStore.userInfo.roles" :key="role">{{ role }}</NTag>
          </NSpace>
        </NDescriptionsItem>
        <NDescriptionsItem ions-item label="使用方法">
          <NSpace>
            <p>import { useAuth } from '@/hooks/business/auth';</p>
            <br />
            <p>const { hasAuth } = useAuth();</p>
            <br />
            <p>v-if="hasAuth('api:SysMenu:Add')"</p>
          </NSpace>
        </NDescriptionsItem>
      </NDescriptions>
    </NCard>
    <NCard
      :title="$t('page.function.toggleAuth.authHook')"
      :bordered="false"
      size="small"
      segmented
      class="card-wrapper"
    >
      <NSpace>
        <NButton v-if="hasAuth('api:SysMenu:Add')">拥有 api:SysMenu:Add 权限可见</NButton>

        <NButton v-if="hasAuth('api:SysMenu:Ad')">拥有api:SysMenu:Ad 权限可见</NButton>
      </NSpace>
    </NCard>
  </NSpace>
</template>

<style scoped></style>
