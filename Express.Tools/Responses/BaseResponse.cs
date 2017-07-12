
/// <summary>
/// 请求响应基础类
/// </summary>
public class BaseResponse
{
    /// <summary>
    /// 商户ID
    /// </summary>
    public string EBusinessID { get; set; }
    /// <summary>
    /// 是否成功
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// 快递单号
    /// </summary>
    public string LogisticCode { get; set; }
    /// <summary>
    /// 失败原因
    /// </summary>
    public int Code { get; set; }
}
