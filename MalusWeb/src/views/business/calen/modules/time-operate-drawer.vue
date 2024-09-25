<script setup lang="ts">
import { reactive, ref, watch } from 'vue';
import { useNaiveForm } from '@/hooks/common/form';
import { addAppmentDate } from '@/service/api';
defineOptions({
  name: 'DateOperateDrawer'
});

interface Props {
  /** the type of operation */
  operateType: NaiveUI.TableOperateType;
}
</script>

<template>
  <NDrawer v-model:show="visible" :title="title" display-directive="show" :width="360"></NDrawer>
</template>

<style scoped></style>
