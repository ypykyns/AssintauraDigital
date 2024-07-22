Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class BLZapsign

    Private ReadOnly apiUrl As String = "https://sandbox.api.zapsign.com.br/api/v1/docs/"
    Private ReadOnly apiToken As String = "dd0b9b73-2e95-4a86-918b-d2d082b2ac9873ce2cf3-f130-41bc-90c3-fa334eddd00e"

    Public Function SendPostRequest(objPessoa As Pessoa, base64Pdf As String) As String
        Dim requestUrl As String = $"{apiUrl}?api_token={apiToken}"

        Dim postData As New With {
        .sandbox = False,
        .name = "Termo de Aceite Insanos MC",
        .base64_pdf = base64Pdf,
        .brand_primary_color = "#000000",
        .lang = "pt-br",
        .external_id = CType(Nothing, String),
        .signers = New Object() {
            New With {
                .name = objPessoa.Nome,
                .email = objPessoa.Email,
                .lock_email = True,
                .lock_phone = True,
                .phone_country = "+55",
                .phone_number = objPessoa.TelCel,
                .auth_mode = "assinaturaTela",
                .send_automatic_email = True,
                .send_automatic_whatsapp = False,
                .require_selfie_photo = True,
                .require_document_photo = True
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
                Return responseData
            End Using
        End Using
    End Function

    Public Function SendGetRequest(docToken As String) As String
        Dim requestUrl As String = $"{apiUrl}{docToken}?api_token={apiToken}"

        Dim request As HttpWebRequest = CType(WebRequest.Create(requestUrl), HttpWebRequest)
        request.Method = "GET"

        Dim response As WebResponse = request.GetResponse()
        Using responseStream As Stream = response.GetResponseStream()
            Using reader As New StreamReader(responseStream)
                Dim responseData As String = reader.ReadToEnd()
                Console.WriteLine(responseData)
                Return responseData
            End Using
        End Using

        Console.WriteLine(response.ToString)

        Return ""
    End Function

End Class
