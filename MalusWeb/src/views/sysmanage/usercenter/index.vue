<script setup lang="ts">
import { ref } from 'vue';
// 抽屉开关
const formRef = ref({
  name: '',
  phone: '',
  email: '',
  remark: ''
});

const rules = {
  user: {
    name: {
      required: true,
      message: '请输入姓名',
      trigger: 'blur'
    },
    age: {
      required: true,
      message: '请输入年龄',
      trigger: ['input', 'blur']
    }
  },
  phone: {
    required: true,
    message: '请输入电话号码',
    trigger: ['input']
  }
};
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NCard title="个人信息" style="margin-bottom: 16px">
      <NTabs type="line" animated>
        <NTabPane name="oasis" tab="信息修改">
          <NForm ref="formRef" inline :label-width="80" :model="formValue" :rules="rules" :size="size">
            <NFormItem label="姓名" path="name">
              <NInput v-model:value="formValue.name" placeholder="输入姓名" />
            </NFormItem>
            <NFormItem label="手机号码" path="phone">
              <NInput v-model:value="formValue.phone" placeholder="手机号码" />
            </NFormItem>
            <NFormItem label="邮箱" path="email">
              <NInput v-model:value="formValue.email" placeholder="邮箱" />
            </NFormItem>
            <NFormItem label="备注" path="remark">
              <NInput v-model:value="formValue.remark" placeholder="备注" />
            </NFormItem>
            <NFormItem>
              <NButton attr-type="button" @click="handleValidateClick">验证</NButton>
            </NFormItem>
          </NForm>
          <pre>{{ JSON.stringify(formRef, null, 2) }}</pre>
        </NTabPane>
        <NTabPane name="the beatles" tab="密码修改"></NTabPane>
      </NTabs>
    </NCard>
  </div>
</template>

<style scoped></style>
