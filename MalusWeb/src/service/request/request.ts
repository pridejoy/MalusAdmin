import axios from 'axios';
import { localStg } from '@/utils/storage';

// 创建axios实例
const request = axios.create({
  baseURL: import.meta.env.VITE_SERVICE_BASE_URL,
  timeout: 5000
});
// 请求拦截器
request.interceptors.request.use(config => {
  const token = localStg.get('token');
  if (token) {
    config.headers.token = token;
  }
  return config;
});
// 响应拦截器
request.interceptors.response.use(
  response => {
    console.log('响应拦截器:', response.data);
    return response.data;
  },
  error => {
    console.log('响应拦截器:', error);
    window.$message?.error(error.message);
    return Promise.reject(error);
  }
);
export default request;
