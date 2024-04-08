import { request } from '../request/';

import request2 from '../request/request';

// 登录接口方法
export const reqLogin = (account: string, passWord: string) => {
  return request2.post<any, any>('api/SysLogin/Login', { account, passWord });
};

/** Get user info */
export const getTokenUserInfo = () => {
  return request2.get<any, any>('api/SysLogin/GetUserInfo');
};

/**
 * Login
 *
 * @param userName User name
 * @param password Password
 */
export function fetchLogin(account: string, passWord: string) {
  return request<any>({
    url: '/SysLogin/Login',
    method: 'post',
    data: {
      account,
      passWord
    }
  });
}

/** Get user info */
export function fetchGetUserInfo() {
  return request<Api.Auth.UserInfo>({ url: '/auth/getUserInfo' });
}

/**
 * Refresh token
 *
 * @param refreshToken Refresh token
 */
export function fetchRefreshToken(refreshToken: string) {
  return request<Api.Auth.LoginToken>({
    url: 'api/auth/refreshToken',
    method: 'post',
    data: {
      refreshToken
    }
  });
}

/**
 * return custom backend error
 *
 * @param code error code
 * @param msg error message
 */
export function fetchCustomBackendError(code: string, msg: string) {
  return request({ url: '/auth/error', params: { code, msg } });
}
