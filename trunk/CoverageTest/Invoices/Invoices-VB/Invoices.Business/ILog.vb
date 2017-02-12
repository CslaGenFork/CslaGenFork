Imports System

Namespace Invoices.Business
	Public Interface ILog
		Property LogAction() As LogActions

		Property LogDateTime() As Date

		Property LogUser() As Integer
	End Interface
End Namespace