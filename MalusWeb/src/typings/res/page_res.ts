// 定义PaginatedData接口
export interface PaginatedData<T> {
  records: T[];
  total: number;
  pageSize: number;
  currentPage: number;
}
