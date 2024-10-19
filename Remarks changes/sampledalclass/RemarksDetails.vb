Imports System.Data
Imports System.Data.SqlClient

Public Class RemarksDetails
    Private _SampleID As Integer
    Private _UserName As String
    Private _Remarks As String

    ' Properties
    Public Property SampleID() As Integer
        Get
            Return _SampleID
        End Get
        Set(ByVal value As Integer)
            _SampleID = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property Remarks() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    ' Method to insert data into Remarks table
    Public Shared Function InsertRemarksDetails(ByVal remarksDetails As RemarksDetails) As Boolean
        With remarksDetails
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@SampleID", .SampleID)
            params(1) = New SqlParameter("@UserName", .UserName)
            params(2) = New SqlParameter("@Remarks", .Remarks)

            Dim storedProcName As String = "InsertRemark"
            Return SqlHelper.ExecuteNonQuery(WebGlobalVariables.Connection2, CommandType.StoredProcedure, storedProcName, params)
        End With
    End Function

End Class
