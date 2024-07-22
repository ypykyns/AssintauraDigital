Imports System
Public Class Utils

    Public Function ConvertDateTime(serverDateTime As DateTime) As DateTime

        ' Fuso horário do servidor (ajustar de acordo com o fuso horário do servidor)
        Dim serverTimeZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("UTC")

        ' Fuso horário local (horário de Brasília)
        Dim localTimeZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")

        ' Converter a hora do servidor para a hora local
        Dim localDateTime As DateTime = TimeZoneInfo.ConvertTime(serverDateTime, serverTimeZone, localTimeZone)

        Return localDateTime

    End Function

End Class
