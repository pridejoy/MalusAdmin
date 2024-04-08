import { createApp } from 'vue';
import './plugins/assets';
import axios from 'axios';
import { setupDayjs, setupIconifyOffline, setupLoading, setupNProgress } from './plugins';
import { setupStore } from './store';
import { setupRouter } from './router';
import { setupI18n } from './locales';
import App from './App.vue';

axios({
  url: 'https://localhost:7154/api/Home/Index',
  method: 'get',
  headers: {
    token: 'a1f3af2394af4bcaa16f08d91190db45'
  }
}).then(res => {
  console.log(res);
});

async function setupApp() {
  setupLoading();

  setupNProgress();

  setupIconifyOffline();

  setupDayjs();

  const app = createApp(App);

  setupStore(app);

  await setupRouter(app);

  setupI18n(app);

  app.mount('#app');
}

setupApp();
