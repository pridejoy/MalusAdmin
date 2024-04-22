import { request } from '../request';

/** 角色分页 */
export function getSysRolePage(params?: Api.SystemManage.RoleSearchParams) {
  return request<Api.SystemManage.Role>({
    url: '/SysRole/PageList',
    method: 'get',
    params
  });
}

// 修改角色
export function updateSysRole(data?: any) {
  return request<boolean>({
    url: '/SysRole/Update',
    method: 'post',
    data
  });
}

/** 角色列表 * */

export function getRolesList() {
  return request<SysRoleList>({
    url: '/SysRole/List',
    method: 'get'
  });
}
