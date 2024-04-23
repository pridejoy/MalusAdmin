<script setup lang="ts">
import { computed } from 'vue';
import { $t } from '@/locales';
import { useAppStore } from '@/store/modules/app';
import pkg from '~/package.json';

const appStore = useAppStore();

const column = computed(() => (appStore.isMobile ? 1 : 2));

interface PkgJson {
  name: string;
  version: string;
  dependencies: PkgVersionInfo[];
  devDependencies: PkgVersionInfo[];
}

interface PkgVersionInfo {
  name: string;
  version: string;
}

const { name, version, dependencies, devDependencies } = pkg;

function transformVersionData(tuple: [string, string]): PkgVersionInfo {
  const [$name, $version] = tuple;
  return {
    name: $name,
    version: $version
  };
}

const pkgJson: PkgJson = {
  name,
  version,
  dependencies: Object.entries(dependencies).map(item => transformVersionData(item)),
  devDependencies: Object.entries(devDependencies).map(item => transformVersionData(item))
};

const latestBuildTime = BUILD_TIME;
</script>

<template>
  <NSpace vertical :size="16">
    <NCard :title="$t('page.about.title')" :bordered="false" size="small" segmented class="card-wrapper">
      <!-- <NDivider /> -->
      <NH3 style="text-align: center">MalusAdmin</NH3>
      <NTabs type="segment" animated>
        <NTabPane name="chap0" tab="简介">
          MalusAdmin 是基于NET Core | NET7 & Sqlsugar | Vue3 | vite4 | TypeScript | NaiveUI
          开发的后台管理框架,提供快速开发解决方案。
          <p>
            文档地址:
            <a class="text-primary" target="_blank" rel="noopener noreferrer" href="https://www.dotnetshare.com/">
              https://www.dotnetshare.com/
            </a>
          </p>
          <p>
            公众号:[Net分享] 一个会持续分享编程干货和好玩的知识库。欢迎大家关注！！！
            <br />
            <NQrCode value="http://weixin.qq.com/r/qzj377TEKulVrfCM9225" />
          </p>
          <p>
            开源地址:
            <a
              class="text-primary"
              target="_blank"
              rel="noopener noreferrer"
              href="https://gitee.com/Pridejoy/MalusAdmin"
            >
              https://gitee.com/Pridejoy/MalusAdmin
            </a>
          </p>
        </NTabPane>
        <NTabPane name="chap1" tab="文档地址">
          <a class="text-primary" target="_blank" rel="noopener noreferrer" href="https://www.dotnetshare.com/">
            https://www.dotnetshare.com/
          </a>
        </NTabPane>
        <NTabPane name="chap2" tab="公众号">
          一个会持续分享编程干货和好玩的知识库。欢迎大家关注！！！
          <br />
          <NQrCode value="http://weixin.qq.com/r/qzj377TEKulVrfCM9225" />
        </NTabPane>
        <NTabPane name="chap3" tab="开源地址">
          <a
            class="text-primary"
            target="_blank"
            rel="noopener noreferrer"
            href="https://gitee.com/Pridejoy/MalusAdmin"
          >
            https://gitee.com/Pridejoy/MalusAdmin
          </a>
        </NTabPane>
        <NTabPane name="chap4" tab="Soybean Admin">
          <p>
            Soybean Admin 是一个优雅且功能强大的后台管理模板，基于最新的前端技术栈，包括 Vue3, Vite5, TypeScript, Pinia
            和 UnoCSS。它内置了丰富的主题配置和组件，代码规范严谨，实现了自动化的文件路由系统。此外，它还采用了基于
            ApiFox 的在线Mock数据方案。Soybean Admin
            为您提供了一站式的后台管理解决方案，无需额外配置，开箱即用。同样是一个快速学习前沿技术的最佳实践。
          </p>
        </NTabPane>
      </NTabs>
    </NCard>
    <NCard :title="$t('page.about.projectInfo.title')" :bordered="false" size="small" segmented class="card-wrapper">
      <NDescriptions label-placement="left" bordered size="small" :column="column">
        <NDescriptionsItem :label="$t('page.about.projectInfo.version')">
          <NTag type="primary">{{ pkgJson.version }}</NTag>
        </NDescriptionsItem>
        <NDescriptionsItem :label="$t('page.about.projectInfo.latestBuildTime')">
          <NTag type="primary">{{ latestBuildTime }}</NTag>
        </NDescriptionsItem>
        <NDescriptionsItem :label="$t('page.about.projectInfo.githubLink')">
          <a class="text-primary" :href="pkg.homepage" target="_blank" rel="noopener noreferrer">
            {{ $t('page.about.projectInfo.githubLink') }}
          </a>
        </NDescriptionsItem>
        <NDescriptionsItem :label="$t('page.about.projectInfo.previewLink')">
          <a class="text-primary" :href="pkg.website" target="_blank" rel="noopener noreferrer">
            {{ $t('page.about.projectInfo.previewLink') }}
          </a>
        </NDescriptionsItem>
      </NDescriptions>
    </NCard>
    <NCard :title="$t('page.about.prdDep')" :bordered="false" size="small" segmented class="card-wrapper">
      <NDescriptions label-placement="left" bordered size="small" :column="column">
        <NDescriptionsItem v-for="item in pkgJson.dependencies" :key="item.name" :label="item.name">
          {{ item.version }}
        </NDescriptionsItem>
      </NDescriptions>
    </NCard>
    <NCard :title="$t('page.about.devDep')" :bordered="false" size="small" segmented class="card-wrapper">
      <NDescriptions label-placement="left" bordered size="small" :column="column">
        <NDescriptionsItem v-for="item in pkgJson.devDependencies" :key="item.name" :label="item.name">
          {{ item.version }}
        </NDescriptionsItem>
      </NDescriptions>
    </NCard>
  </NSpace>
</template>

<style scoped></style>
