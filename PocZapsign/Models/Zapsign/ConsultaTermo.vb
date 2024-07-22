Imports Newtonsoft.Json

Public Class ConsultaTermo
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property sandbox As Boolean
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property external_id As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property open_id As Integer
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property token As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property name As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property folder_path As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property status As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property rejected_reason As Object
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property lang As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property original_file As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property signed_file As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property extra_docs As List(Of Object)
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property created_through As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property deleted As Boolean
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property deleted_at As Object
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property signed_file_only_finished As Boolean
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property disable_signer_emails As Boolean
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property brand_logo As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property brand_primary_color As String
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property created_at As DateTime
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property last_update_at As DateTime
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property created_by As CreatedBy
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property template As Object
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property signers As List(Of Signer)
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property answers As List(Of Object)
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property auto_reminder As Integer
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property signature_report As Object
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property tsa_country As Object
    <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
    Public Property use_timestamp As Boolean

    Public Class CreatedBy
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property email As String
    End Class

    Public Class Signer
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property external_id As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property sign_url As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property token As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property status As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property name As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property lock_name As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property email As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property lock_email As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property hide_email As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property blank_email As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property phone_country As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property phone_number As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property lock_phone As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property hide_phone As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property blank_phone As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property times_viewed As Integer
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property last_view_at As DateTime
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property signed_at As DateTime
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property auth_mode As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property qualification As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property require_selfie_photo As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property require_document_photo As Boolean
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property geo_latitude As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property geo_longitude As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property redirect_link As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property signature_image As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property visto_image As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property document_photo_url As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property document_verse_photo_url As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property selfie_photo_url As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property selfie_photo_url2 As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property send_via As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property resend_attempts As Object
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property cpf As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property cnpj As String
        <JsonProperty(NullValueHandling:=NullValueHandling.Ignore)>
        Public Property send_automatic_whatsapp_signed_file As Boolean
    End Class
End Class
