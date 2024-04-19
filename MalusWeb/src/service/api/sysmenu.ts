import { request } from '../request';

/** 角色分页 */
export function getMenuTreeList() {
  return request<Api.SystemManage.MenuList>({
    url: 'SysMenu/MenuTreeList',
    method: 'get'
  });
}
