import { request } from '../request';

/** 角色分页 */
export function getSysRolePage(params?: any) {
  return request<Api.SystemManage.Role>({
    url: '/SysRole/PageList',
    method: 'get',
    params
  });
}

/** 角色列表 * */

export function getRolesList() {
  return request<SysRoleList>({
    url: '/SysRole/List',
    method: 'get'
  });
}
