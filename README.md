# netLearning
net学习
1、字符串转日期类型：var begintime = Convert.ToDateTime(beginDatetime);
2、事务的使用：using (var db = new MeiCloudDb())
{
try
{
// 开启事务
db.BeginTransaction();

// 提交事务
db.CommitTransaction();

}
catch (Exception ex)
{
// 回滚事务
db.RollbackTransaction();
throw ex;
}

}
3、 模糊查询
var inspectionFirstBarcodeList = query.Where(a => a.SCHE_ID.Contains("aa")).Distinct();  模糊查询
4、  db.Select(() => Sql.CurrentTimestamp);  获取当前时间
5、分页 
var orgs = from o in db.SYS_ORG
           where o.STATE == "A"
           && (string.IsNullOrWhiteSpace(orgId) || o.ID == orgId)
           && (string.IsNullOrWhiteSpace(orgCode) || o.ORG_CODE == orgCode)
           select o;
 
totalRecords = orgs.Count();
var result = orgs.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

分页：temp.Skip((start - 1) * length).Take(length).ToList();

多表连接和group by and order by
var query =from a in this.ObjectContext.siteInfo 
       join b in this.ObjectContext.shopInfo on a.siteID equals b.siteID 
       group new {a,b} by new { a.Lon, a.Lat, a.siteID, b.date} into g 
       select new site_shopInfo{
         SiteID=g.Key.siteID,
         Longitude=g.Key.Lon, 
         Latitude=g.Key.Lat, 
         date=g.Key.date, 
         Totalearning=g.Sum(t => t.b.earning)};

List<MoStationWipReportModel> dataList = scheduleData.GroupBy(x => new
                {
                    x.ID,
                    x.MITEM_CODE,
                    x.MITEM_DESC,
                    x.MO_CODE,
                    x.SCHE_NO,
                    x.WORKSHOP_CODE,
                    x.DATETIME_PLAN_START,
                    x.WORKSHOP_NAME
                })
                                      .OrderBy(x => new { x.Key.DATETIME_PLAN_START, x.Key.MITEM_CODE })
                                      .Select(x => new MoStationWipReportModel
                                      {
                                          ID = x.Key.ID,
                                          MITEM_CODE = x.Key.MITEM_CODE,
                                          MITEM_DESC = x.Key.MITEM_DESC,
                                          MO_CODE = x.Key.MO_CODE,
                                          SCHE_NO = x.Key.SCHE_NO,
                                          WORKSHOP_CODE = x.Key.WORKSHOP_CODE,
                                          DATETIME_PLAN_START = x.Key.DATETIME_PLAN_START,
                                          WORKSHOP_NAME = x.Key.WORKSHOP_NAME,
                                          PLAN_QTY = x.Sum(t => t.PLAN_QTY)
                                      }).ToList();
