import { request } from '../request';

/** get role list */
export function getSysRoleAllPermission(params?: any) {
  return request<ResRolePermission>({
    url: '/SysRolePermissionComtroller/GetAllButen',
    method: 'get',
    params
  });
}
