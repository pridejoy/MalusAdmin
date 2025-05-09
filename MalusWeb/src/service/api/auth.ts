import { request } from '../request/';

/**
 * Login
 *
 * @param userName User name
 * @param password Password
 */
export function reqLogin(account: string, passWord: string) {
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
export function getTokenUserInfo() {
  return request<Api.Auth.UserInfo>({ url: '/SysLogin/GetUserInfo' });
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

// 修改基本资料;
export function updateUserInfo(data: any) {
  return request<boolean>({
    url: '/syslogin/updateuserinfo',
    method: 'post',
    data
  });
}

// 重置密码
export function resetPassWord(data: any) {
  return request<boolean>({
    url: '/syslogin/resetpassword',
    method: 'post',
    data
  });
}
