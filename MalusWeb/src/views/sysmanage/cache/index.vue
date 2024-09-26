<!--  -->
<script setup lang="tsx">
import { ref } from 'vue';
import type { TreeOption } from 'naive-ui';
import VueJsonPretty from 'vue-json-pretty';
import 'vue-json-pretty/lib/styles.css';

const data = createData();
const defaultExpandedKeys = ref(['40', '41']);
function createData(level = 4, baseKey = ''): TreeOption[] | undefined {
  if (!level) return undefined;
  return [
    {
      whateverLabel: 'Level 2, Index 0',
      whateverKey: 'root21',
      whateverChildren: [
        {
          whateverLabel: 'Level 1, Index 0',
          whateverKey: 'root21_1',
          whateverChildren: [
            {
              whateverLabel: 'Level 0, Index 0',
              whateverKey: 'root21_1_1',
              whateverChildren: undefined
            },
            {
              whateverLabel: 'Level 0, Index 1',
              whateverKey: 'root21_1_2',
              whateverChildren: undefined
            }
          ]
        },
        {
          whateverLabel: 'Level 1, Index 1',
          whateverKey: 'root21_2',
          whateverChildren: [
            {
              whateverLabel: 'Level 0, Index 0',
              whateverKey: 'root21_2_1',
              whateverChildren: undefined
            },
            {
              whateverLabel: 'Level 0, Index 1',
              whateverKey: 'root21_2_2',
              whateverChildren: undefined
            }
          ]
        }
      ]
    },
    {
      whateverLabel: 'Level 2, Index 1',
      whateverKey: 'root22',
      whateverChildren: [
        {
          whateverLabel: 'Level 1, Index 0',
          whateverKey: 'root22_1',
          whateverChildren: [
            {
              whateverLabel: 'Level 0, Index 0',
              whateverKey: 'root22_1_1',
              whateverChildren: undefined
            },
            {
              whateverLabel: 'Level 0, Index 1',
              whateverKey: 'root22_1_2',
              whateverChildren: undefined
            }
          ]
        },
        {
          whateverLabel: 'Level 1, Index 1',
          whateverKey: 'root22_2',
          whateverChildren: [
            {
              whateverLabel: 'Level 0, Index 0',
              whateverKey: 'root22_2_1',
              whateverChildren: undefined
            },
            {
              whateverLabel: 'Level 0, Index 1',
              whateverKey: 'root22_2_2',
              whateverChildren: undefined
            }
          ]
        }
      ]
    }
  ];
}
</script>

<template>
  <div class="min-h-500px flex-col-stretch gap-16px overflow-hidden lt-sm:overflow-auto">
    <NRow gutter="24">
      <NCol :span="7">
        <NCard
          title="缓存列表"
          :bordered="false"
          size="small"
          class="sm:flex-1-hidden card-wrapper"
          :segmented="{
            content: true,
            footer: 'soft'
          }"
        >
          <template #header-extra>
            <div class="button-container">
              <NButton size="small" @click="refresh">
                <template #icon>
                  <icon-mdi-refresh class="text-icon" :class="{ 'animate-spin': loading }" />
                </template>
                刷新
              </NButton>

              <NButton size="small" ghost type="error">
                <template #icon>
                  <icon-ic-round-delete class="text-icon" />
                </template>
                删除
              </NButton>
            </div>
          </template>
          <NTree
            block-line
            :data="data"
            :default-expanded-keys="defaultExpandedKeys"
            key-field="whateverKey"
            label-field="whateverLabel"
            children-field="whateverChildren"
            selectable
          />
        </NCard>
      </NCol>
      <NCol :span="17">
        <NCard
          title="缓存数据"
          :bordered="false"
          size="small"
          class="sm:flex-1-hidden card-wrapper"
          :segmented="{
            content: true,
            footer: 'soft'
          }"
        >
          <div>
            <VueJsonPretty
              show-length
              show-icon
              virtual
              show-line-number
              show-select-controller
              style="padding-bottom: 60px"
              :data="data"
            ></VueJsonPretty>
          </div>
        </NCard>
      </NCol>
    </NRow>
  </div>
</template>

<style lang="scss" scoped>
.button-container {
  display: flex;
  gap: 8px; /* 或者您想要的任何间距 */
}
</style>
