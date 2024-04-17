import { request } from '../request';

/** 角色分页 */
export function getSysRolePage(params?: Api.SystemManage.RoleSearchParams) {
  return request<Api.SystemManage.Role>({
    url: '/SysUser/PageList',
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
