import { request } from '../request';

/** get role list */
export function getSysRoleAllPermission(params?: any) {
  return request<ResRolePermission>({
    url: '/SysRolePermissionComtroller/GetAllButen',
    method: 'get',
    params
  });
}

// 获取用户的权限按钮
export function getRoleButen(params?: any) {
  return request<string[]>({
    url: '/SysRolePermissionComtroller/GetRoleButen',
    method: 'get',
    params
  });
}

// 添加用户的权限按钮
export function addUserButtonPermiss(data?: any) {
  return request<string[]>({
    url: '/SysRolePermissionComtroller/AddUserButtonPermiss',
    method: 'post',
    data
  });
}
