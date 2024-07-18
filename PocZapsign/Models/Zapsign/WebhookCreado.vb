Public Class WebhookCreado
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
    Public Property extra_docs() As Object
    Public Property created_through As String
    Public Property deleted As Boolean
    Public Property deleted_at As Object
    Public Property signed_file_only_finished As Boolean
    Public Property disable_signer_emails As Boolean
    Public Property brand_logo As String
    Public Property brand_primary_color As String
    Public Property created_at As Date
    Public Property last_update_at As Date
    Public Property created_by As Created_By
    Public Property template As Object
    Public Property signers() As Signer
    Public Property answers() As Object
    Public Property auto_reminder As Integer
    Public Property signature_report As Object
    Public Property tsa_country As Object
    Public Property use_timestamp As Boolean
    Public Property event_type As String
End Class

Public Class Created_By
    Public Property email As String
End Class

