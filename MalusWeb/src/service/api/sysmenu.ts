import { request } from '../request';

/** 角色分页 */
export function getMenuTreeList(params?: any) {
  return request<MenuTreeRes>({
    url: 'SysMenu/MenuTreeList',
    method: 'get',
    params
  });
}
