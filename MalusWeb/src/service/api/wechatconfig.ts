import type { BsWechatConfigRes } from '@/types/res/BsWechatConfig';
import { request } from '../request';

export function getWechatconfigPage(params?: Api.SystemManage.UserSearchParams) {
  return request<BsWechatConfigRes>({
    url: '/BsWechatConfig/PageList',
    method: 'get',
    params
  });
}

// 修改用户
export function upConfig(data?: any) {
  return request<boolean>({
    url: '/SysUser/Update',
    method: 'post',
    data
  });
}

// 添加p
export function addConfig(data: any) {
  return request<boolean>({
    url: `/BsWechatConfig/Add`,
    method: 'post',
    data
  });
}

// 删除用户
export function deleteConfig(id?: number) {
  return request<boolean>({
    url: `/BsWechatConfig/Delete/${id}`,
    method: 'post'
  });
}
