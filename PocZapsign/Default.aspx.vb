Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class _Default
    Inherits Page

    Private ReadOnly apiUrl As String = "https://sandbox.api.zapsign.com.br/api/v1/docs/"
    Private ReadOnly apiToken As String = "23c86d47-2486-46f6-a433-b73444738906e518c006-671a-4a19-ada7-773ad2ed0ff5"

    Public Sub SendPostRequest(base64Pdf As String)
        Dim requestUrl As String = $"{apiUrl}?api_token={apiToken}"

        Dim postData As New With {
        .sandbox = False,
        .name = "My Contract",
        .base64_pdf = base64Pdf,
        .brand_primary_color = "#000000",
        .lang = "pt-br",
        .external_id = CType(Nothing, String),
        .signers = New Object() {
            New With {
                .name = "",
                .email = txtEmail.Text,
                .lock_email = True,
                .lock_phone = True,
                .phone_country = "YOUR_COUNTRY_PREFIX",
                .phone_number = "YOUR_PHONE_NUMBER",
                .auth_mode = "assinaturaTela",
                .send_automatic_email = True,
                .send_automatic_whatsapp = True,
                .require_selfie_photo = True
            }
        }
    }

        Dim json As String = JsonConvert.SerializeObject(postData)
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(json)

        Dim request As HttpWebRequest = CType(WebRequest.Create(requestUrl), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.ContentLength = byteArray.Length

        Using dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
        End Using

        Dim response As WebResponse = request.GetResponse()
        Using responseStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(responseStream)
                Dim responseData As String = reader.ReadToEnd()
                Console.WriteLine(responseData)
                textRetorno.Text = responseData
            End Using
        End Using
    End Sub

    Protected Sub BtnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click

        If FileUpload1.HasFile AndAlso FileUpload1.PostedFile.ContentType = "application/pdf" Then
            Dim base64Pdf As String = ConvertToBase64(FileUpload1.PostedFile.InputStream)
            SendPostRequest(base64Pdf)
        Else
            Response.Write("Por favor, selecione um arquivo PDF.")
        End If

    End Sub

    Private Function ConvertToBase64(inputStream As Stream) As String
        Using memoryStream As New MemoryStream()
            inputStream.CopyTo(memoryStream)
            Dim fileBytes As Byte() = memoryStream.ToArray()
            Return Convert.ToBase64String(fileBytes)
        End Using
    End Function

    Private Sub Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub
End Class