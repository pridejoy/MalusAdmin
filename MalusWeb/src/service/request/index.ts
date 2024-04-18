import type { AxiosResponse } from 'axios';
import { BACKEND_ERROR_CODE, createFlatRequest, createRequest } from '@sa/axios';
import { useAuthStore } from '@/store/modules/auth';
import { localStg } from '@/utils/storage';
// import { getServiceBaseURL } from '@/utils/service';
import { $t } from '@/locales';
import { handleRefreshToken } from './shared';

// const isHttpProxy = import.meta.env.DEV && import.meta.env.VITE_HTTP_PROXY === 'Y';
// const { baseURL, otherBaseURL } = getServiceBaseURL(import.meta.env, isHttpProxy);

const baseURL = import.meta.env.VITE_SERVICE_BASE_URL;
// console.log('baseURL', baseURL);

interface InstanceState {
  /** whether the request is refreshing token */
  isRefreshingToken: boolean;
}

export const request = createFlatRequest<App.Service.Response, InstanceState>(
  {
    baseURL
  },
  {
    async onRequest(config) {
      const { headers } = config;

      // set token
      const token = localStg.get('token');
      // const Authorization = token ? `${token}` : null;
      // 更改 请求头信息
      headers.Token = token ? `${token}` : null;
      // Object.assign(headers, { Authorization });

      return config;
    },
    isBackendSuccess(response) {
      // when the backend response code is "0000"(default), it means the request is success
      // to change this logic by yourself, you can modify the `VITE_SERVICE_SUCCESS_CODE` in `.env` file
      // console.log('response1', response.data.code === import.meta.env.VITE_SERVICE_SUCCESS_CODE);
      // console.log('response2', response.data.code);
      // console.log('response3', import.meta.env.VITE_SERVICE_SUCCESS_CODE);
      return response.data.code == import.meta.env.VITE_SERVICE_SUCCESS_CODE;
    },
    async onBackendFail(response, instance) {
      const authStore = useAuthStore();

      function handleLogout() {
        authStore.resetStore();
      }

      function logoutAndCleanup() {
        handleLogout();
        window.removeEventListener('beforeunload', handleLogout);
      }

      // 当后端响应代码在logoutCodes中时，意味着用户将会登出并被重定向到登录页面。
      const logoutCodes = import.meta.env.VITE_SERVICE_LOGOUT_CODES?.split(',') || [];
      if (logoutCodes.includes(response.data.code)) {
        handleLogout();
        return null;
      }

      // 当后端响应代码在modalLogoutCodes中时，意味着用户将会通过显示一个模态框来被登出。
      const modalLogoutCodes = import.meta.env.VITE_SERVICE_MODAL_LOGOUT_CODES?.split(',') || [];
      if (modalLogoutCodes.includes(response.data.code)) {
        // 阻止用户刷新页面
        window.addEventListener('beforeunload', handleLogout);

        window.$dialog?.error({
          title: 'Error',
          content: response.data.message,
          positiveText: $t('common.confirm'),
          maskClosable: false,
          onPositiveClick() {
            logoutAndCleanup();
          },
          onClose() {
            logoutAndCleanup();
          }
        });

        return null;
      }

      // 当后端响应代码处于“expiredTokeCodes”中时，表示令牌已过期，并刷新令牌
      // api“refreshToken”不能在“expiredTokeCodes”中返回错误代码，否则它将是一个死循环，应返回“logoutCodes”或“modalLogoutCodes”`
      const expiredTokenCodes = import.meta.env.VITE_SERVICE_EXPIRED_TOKEN_CODES?.split(',') || [];
      if (expiredTokenCodes.includes(response.data.code) && !request.state.isRefreshingToken) {
        request.state.isRefreshingToken = true;

        const refreshConfig = await handleRefreshToken(response.config);

        request.state.isRefreshingToken = false;

        if (refreshConfig) {
          return instance.request(refreshConfig) as Promise<AxiosResponse>;
        }
      }

      return null;
    },
    transformBackendResponse(response) {
      // console.log('请求返回信息:', response.data.body);
      return response.data.body;
    },
    onError(error) {
      // 当请求失败时，您可以显示错误消息
      console.log('当请求失败', error);
      let message = error.message;
      let backendErrorCode = '';

      // 获取后端错误消息和代码
      if (error.code === BACKEND_ERROR_CODE) {
        message = error.response?.data?.message || message;
        backendErrorCode = error.response?.data?.code || '';
      }

      // 错误消息显示在模态中
      const modalLogoutCodes = import.meta.env.VITE_SERVICE_MODAL_LOGOUT_CODES?.split(',') || [];
      if (modalLogoutCodes.includes(backendErrorCode)) {
        return;
      }

      // 当令牌过期时，刷新令牌并重试请求，因此无需显示错误消息
      const expiredTokenCodes = import.meta.env.VITE_SERVICE_EXPIRED_TOKEN_CODES?.split(',') || [];
      if (expiredTokenCodes.includes(backendErrorCode)) {
        return;
      }

      window.$message?.error?.(message);
    }
  }
);
