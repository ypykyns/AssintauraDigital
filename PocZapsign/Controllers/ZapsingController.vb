Imports System.Net
Imports System.Web.Http

Public Class ZapsingController
    Inherits ApiController

    ' POST api/zapsing/document-created
    <HttpPost>
    <Route("api/zapsing/document-created")>
    Public Function DocumentCreated(<FromBody()> ByVal data As WebhookCreado) As IHttpActionResult
        Return Ok(data)
    End Function

    ' POST api/zapsing/document-signed
    <HttpPost>
    <Route("api/zapsing/document-signed")>
    Public Function DocumentSigned(<FromBody()> ByVal data As WebhookAssinado) As IHttpActionResult
        Return Ok(data)
    End Function
End Class
