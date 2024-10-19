Imports System.Data
Imports System.Data.SqlClient

Public Class RemarksDetails
    ' Private fields for encapsulation
    Private _SampleID As String
    Private _UserName As String
    Private _Remarks As String

    ' Properties to expose private fields
    Public Property SampleID() As String
        Get
            Return _SampleID
        End Get
        Set(ByVal value As String)
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

    ' Method to insert data into Remarks table using the stored procedure
    Public Shared Function InsertRemarksDetails(ByVal remarksDetails As RemarksDetails) As Boolean
        Try
            ' Prepare SQL parameters
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@SampleReqizitionID", remarksDetails.SampleID)
            params(1) = New SqlParameter("@UserName", remarksDetails.UserName)
            params(2) = New SqlParameter("@Remarks", remarksDetails.Remarks)

            ' Specify the name of the stored procedure
            Dim storedProcName As String = "InsertRemarks"

            ' Execute the stored procedure and return true if successful
            Return SqlHelper.ExecuteNonQuery(WebGlobalVariables.Connection2, CommandType.StoredProcedure, storedProcName, params) > 0
        Catch ex As Exception
            ' Log or handle exception
            Return False
        End Try
    End Function
End Class
