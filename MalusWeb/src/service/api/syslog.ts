import { request } from '../request';

/** 角色分页 */
export function getSyslogPage(params?: any) {
  return request<sysLogPageRes>({
    url: '/SysLog/PageList',
    method: 'get',
    params
  });
}
