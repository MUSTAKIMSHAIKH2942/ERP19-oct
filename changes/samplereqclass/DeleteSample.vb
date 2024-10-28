Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class DeleteSample
    Private _DeleteID As Integer
    Private _SampleReqizitionID As Integer
    Private _SRRefID As String
    Private _Reason As String
    Private _InsertedDate As DateTime

    ' Properties
    Public Property DeleteID() As Integer
        Get
            Return _DeleteID
        End Get
        Set(ByVal value As Integer)
            _DeleteID = value
        End Set
    End Property

    Public Property SampleReqizitionID() As Integer
        Get
            Return _SampleReqizitionID
        End Get
        Set(ByVal value As Integer)
            _SampleReqizitionID = value
        End Set
    End Property

    Public Property SRRefID() As String
        Get
            Return _SRRefID
        End Get
        Set(ByVal value As String)
            _SRRefID = value
        End Set
    End Property

    Public Property Reason() As String
        Get
            Return _Reason
        End Get
        Set(ByVal value As String)
            _Reason = value
        End Set
    End Property

    Public Property InsertedDate() As DateTime
        Get
            Return _InsertedDate
        End Get
        Set(ByVal value As DateTime)
            _InsertedDate = value
        End Set
    End Property

    ' Method to insert data into DeleteSample
    Public Shared Function InsertDeleteSample(ByVal paramDeleteSample As DeleteSample) As Boolean
        With paramDeleteSample
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@SampleReqizitionID", .SampleReqizitionID)
            params(1) = New SqlParameter("@SRRefID", .SRRefID)
            params(2) = New SqlParameter("@Reason", .Reason)

            Dim storedProcName As String = "InsertDeleteSample"
            DeleteFromRMCPLRequisition(.SampleReqizitionID)
            ' Call the SQL helper to execute the insert operation
            Return SqlHelper.ExecuteNonQuery(WebGlobalVariables.Connection2, CommandType.StoredProcedure, storedProcName, params)
        End With
    End Function

    ' Method to delete from RMCPL_REQUISITION
    Public Shared Function DeleteFromRMCPLRequisition(ByVal sampleReqID As Integer) As String
        Dim message As String = String.Empty

        Dim deleteParams(0) As SqlParameter
        deleteParams(0) = New SqlParameter("@SampleReqizitionID", sampleReqID)

        ' Use raw SQL command to delete the entry
        Dim deleteQuery As String = "DELETE FROM RMCPL_REQUISITION WHERE RMCPL_TID = @SampleReqizitionID"
        Dim rowsAffected As Integer = SqlHelper.ExecuteNonQuery(WebGlobalVariables.Connection2, CommandType.Text, deleteQuery, deleteParams)

        If rowsAffected > 0 Then
            message = "Entry deleted successfully from RMCPL_REQUISITION."
        Else
            message = "No entry found to delete from RMCPL_REQUISITION."
        End If

        Return message ' Return the message indicating the outcome of the delete operation
    End Function
End Class
