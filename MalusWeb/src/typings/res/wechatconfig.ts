export interface BsWechatConfigRes extends Api.Common.PaginatingQueryRecord {
  configID: number;
  configKey: string;
  configdDescribe: number;
  isDeleted: string;
}
