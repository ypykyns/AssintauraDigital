Imports Newtonsoft.Json

Public Class RetornoAssinatura
    Public Property sandbox As Boolean
    Public Property external_id As String
    Public Property open_id As Integer
    Public Property token As String
    Public Property name As String
    Public Property folder_path As String
    Public Property status As String
    Public Property rejected_reason As Object
    Public Property lang As String
    Public Property original_file As String
    Public Property signed_file As Object
    Public Property extra_docs As List(Of Object)
    Public Property created_through As String
    Public Property deleted As Boolean
    Public Property deleted_at As Object
    Public Property signed_file_only_finished As Boolean
    Public Property disable_signer_emails As Boolean
    Public Property brand_logo As String
    Public Property brand_primary_color As String
    Public Property created_at As String
    Public Property last_update_at As String
    Public Property created_by As CreatedBy
    Public Property template As Object
    Public Property signers As List(Of Signer)
    Public Property answers As List(Of Object)
    Public Property auto_reminder As Integer
    Public Property signature_report As Object
    Public Property tsa_country As Object
    Public Property use_timestamp As Boolean
End Class

Public Class CreatedBy
    Public Property email As String
End Class

Public Class Signer
    Public Property external_id As String
    Public Property sign_url As String
    Public Property token As String
    Public Property status As String
    Public Property name As String
    Public Property lock_name As Boolean
    Public Property email As String
    Public Property lock_email As Boolean
    Public Property hide_email As Boolean
    Public Property blank_email As Boolean
    Public Property phone_country As String
    Public Property phone_number As String
    Public Property lock_phone As Boolean
    Public Property hide_phone As Boolean
    Public Property blank_phone As Boolean
    Public Property times_viewed As Integer
    Public Property last_view_at As Object
    Public Property signed_at As Object
    Public Property auth_mode As String
    Public Property qualification As String
    Public Property require_selfie_photo As Boolean
    Public Property require_document_photo As Boolean
    Public Property geo_latitude As Object
    Public Property geo_longitude As Object
    Public Property redirect_link As String
    Public Property signature_image As Object
    Public Property visto_image As Object
    Public Property document_photo_url As String
    Public Property document_verse_photo_url As String
    Public Property selfie_photo_url As String
    Public Property selfie_photo_url2 As String
    Public Property send_via As String
    Public Property resend_attempts As Object
    Public Property cpf As String
    Public Property cnpj As String
    Public Property send_automatic_whatsapp_signed_file As Object
End Class
