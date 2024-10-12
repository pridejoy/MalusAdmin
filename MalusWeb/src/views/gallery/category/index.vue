<!--  -->
<script setup lang="ts">
import { ref } from 'vue';
import { LazyImg, Waterfall } from 'vue-waterfall-plugin-next';
import 'vue-waterfall-plugin-next/dist/style.css';

const imageList = ref([
  // 假设每个 item 有一个 src 属性指向图片
  { src: 'https://image.meiye.art/pic_1700634840507' },
  { src: 'https://image.meiye.art/pic_1629358896940pFVTf3STAomHWstneQnay' },
  { src: 'https://image.meiye.art/pic_W4bSnMDhxm4M3ymuZX0ht' },
  { src: 'https://image.meiye.art/pic_Thf5O8Zv_aY2yQ77posrd' },
  { src: 'https://image.meiye.art/pic_1629358896940pFVTf3STAomHWstneQnay' },
  { src: 'https://image.meiye.art/pic_W4bSnMDhxm4M3ymuZX0ht' },
  { src: 'https://image.meiye.art/pic_Thf5O8Zv_aY2yQ77posrd' },
  { src: 'https://image.meiye.art/pic_1629358896940pFVTf3STAomHWstneQnay' },
  { src: 'https://image.meiye.art/pic_W4bSnMDhxm4M3ymuZX0ht' }
  // ...更多图片
]);

function addimg() {
  for (let index = 0; index < 50; index++) {
    imageList.value.push({ src: 'https://image.meiye.art/pic_W4bSnMDhxm4M3ymuZX0ht' });
  }
}

addimg();
</script>

<template>
  <div id="content">
    <Waterfall :list="imageList">
      <!-- v2.6.0之前版本插槽数据获取 -->
      <!-- <template #item="{ item, url, index }"> -->
      <!-- 新版插槽数据获取 -->
      <template #default="{ url }">
        <div class="card">
          <LazyImg :url="url" />
          <!-- <p class="text">这是具体内容</p> -->
        </div>
      </template>
    </Waterfall>
  </div>
</template>

<style lang="scss" scoped>
#content {
  position: absolute;
  bottom: 0;
  width: 100%;
}

.card {
  width: 200px;
  /* 卡片宽度 */
  margin: 10px;
  /* 卡片间隔 */
}
</style>
