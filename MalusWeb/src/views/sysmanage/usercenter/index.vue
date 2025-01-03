<script setup lang="ts">
import { ref } from 'vue';
import { getTokenUserInfo, resetPassWord, updateUserInfo } from '@/service/api';
import { useAuthStore } from '@/store/modules/auth';
import { useRouterPush } from '@/hooks/common/router';
const authStore = useAuthStore();
const { toLogin } = useRouterPush();
// 抽屉开关
const formValue = ref({
  name: '',
  tel: '',
  email: '',
  remark: ''
});

const formResetPassWord = ref({
  newPassWord: '',
  oldPassWord: ''
});

const rules = {
  name: {
    required: true,
    message: '请输入姓名',
    trigger: 'blur'
  },
  email: {
    required: true,
    message: '请输入邮箱',
    trigger: ['input', 'blur']
  },
  tel: {
    required: true,
    message: '请输入电话号码',
    trigger: ['input']
  }
};

getuserData();

function getuserData() {
  getTokenUserInfo().then(res => {
    formValue.value = res.data?.userInfo;
  });
}
function handleValidateClick() {
  // 在这里添加处理逻辑
  updateUserInfo(formValue.value).then(res => {
    if (res.data) {
      window.$message?.success?.('修改成功');
      getuserData();
    }
  });
}

function handleSetPassWord() {
  // 在这里添加处理逻辑
  resetPassWord(formResetPassWord.value).then(res => {
    if (res.data) {
      window.$message?.success?.('更改密码成功');
      authStore.resetStore();
      toLogin();
    }
  });
}
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NCard title="个人信息" style="margin-bottom: 16px">
      <NTabs type="line" animated>
        <NTabPane name="oasis" tab="信息修改">
          <div style="width: 60%">
            <NForm ref="form" :label-width="10" :model="formValue" :rules="rules">
              <NFormItem label="姓名" path="name">
                <NInput v-model:value="formValue.name" placeholder="输入姓名" />
              </NFormItem>
              <NFormItem label="手机号码" path="tel">
                <NInput v-model:value="formValue.tel" placeholder="手机号码" />
              </NFormItem>
              <NFormItem label="邮箱" path="email">
                <NInput v-model:value="formValue.email" placeholder="邮箱" />
              </NFormItem>
              <NFormItem label="备注" path="remark">
                <NInput v-model:value="formValue.remark" placeholder="备注" />
              </NFormItem>
              <NFormItem>
                <NButton type="info" @click="handleValidateClick">更改基础资料</NButton>
              </NFormItem>
            </NForm>
          </div>

          <NDivider />
          <pre>{{ JSON.stringify(formValue, null, 2) }}</pre>
        </NTabPane>
        <NTabPane name="the beatles" tab="密码修改">
          <NForm ref="formreset" :label-width="10" :model="formResetPassWord" :rules="rules">
            <NFormItem label="旧密码" path="name">
              <NInput v-model:value="formResetPassWord.oldPassWord" placeholder="输入旧密码" />
            </NFormItem>
            <NFormItem label="新密码" path="tel">
              <NInput v-model:value="formResetPassWord.newPassWord" placeholder="输入新密码" />
            </NFormItem>

            <NFormItem>
              <NButton type="info" @click="handleSetPassWord">更改密码</NButton>
            </NFormItem>

            <NDivider />
            <pre>{{ JSON.stringify(formResetPassWord, null, 2) }}</pre>
          </NForm>
        </NTabPane>
      </NTabs>
    </NCard>
  </div>
</template>

<style scoped></style>
