Imports AccountSolution.FromAccountClassLibrary.Entities
Imports AccountSolution.SqliteClassLibrary

Public Class Trade
    Private objSource As Object
    Public blGood As Boolean
    Public strBeg, strEnd, strNameElement As String
    Public strNumbDoc, strDateDoc As String
    Private objSourcePrice As Object
    Private ReadOnly result As Integer
    Private ReadOnly intTrade As Integer

    Public Sub New()
        Console.WriteLine()
        objSource = CreateObject("V77.Application")
        intTrade = objSource.RMTrade
        result = objSource.Initialize(intTrade, "", "NO_SPLASH_SHOW")
        If result = 0 Then
            'MsgBox("Not open!")
            blGood = False
            Exit Sub
        Else
            blGood = True
        End If
    End Sub

    '//  ********************************************************
    '//  Перенос расходных накладных
    Public Sub BillMove(dBeg As String, dEnd As String)
        Dim _Bill As Bill = New Bill
        Dim _BillLine As BillLine = New BillLine
        Dim _SQLiteBillProvider As SQLiteBillProvider = New SQLiteBillProvider
        objSourcePrice = objSource.CreateObject("Документ.РасходнаяНакладная")
        _SQLiteBillProvider.DeleteBillAll()
        _SQLiteBillProvider.DeleteBillLineAll()
        '    Dim dbs As Database
        '    Dim rstDest, rstDestDet, rstRest As Recordset
        '    Dim InvNumb, Store, Ïàðòèÿ, Ïðîâ
        '    Dim objSource, objDist As Object
        '    Dim objSourcePrice, objDistPrice As Object
        '    Dim Result As Byte
        '    Dim Price, objSQL As Object
        '    Dim strSQL As String
        '   ***************************************************************
        '   Расходные накладные
        '   ***************************************************************
        objSourcePrice.ВыбратьДокументы(dBeg, dEnd)        'Convert.ToDateTime(DateTime)
        While objSourcePrice.ПолучитьДокумент() = 1
            Console.WriteLine("Накладная № " & objSourcePrice.НомерДок & " от " & objSourcePrice.ДатаДок)
            ''Debug.Print "Накладная № " & objSourcePrice.НомерДок & " от " & objSourcePrice.ДатаДок
            '    rstDest.AddNew
            '    Debug.Print objSourcePrice.НомерДок & " | " & objSourcePrice.ДатаДок
            _Bill.OrderGuid = objSourcePrice.НомерДок
            _Bill.DateDoc = objSourcePrice.ДатаДок
            '    If Len(Trim(objSourcePrice.Контрагент.Родитель.Код)) <> 0 Then
            '        rstDest!CustomerParent = objSourcePrice.Контрагент.Родитель.Код
            '    End If
            '    rstDest!CustomerID = objSourcePrice.Контрагент.Код
            _Bill.DeliveryName = objSourcePrice.Контрагент.Наименование
            '    rstDest!FIO = objSourcePrice.FIO
            '    rstDest!Division = objSourcePrice.Участок.Наименование
            '    rstDest!StorID = objSourcePrice.МестоХранения.Код
            '    rstDest!CheckStorID = objSourcePrice.МестоХранения.Наименование
            '    rstDest!Acc = objSourcePrice.СчетКонтрагента.Код
            '    rstDest!Contract = objSourcePrice.Заказ.НомерДок
            '    rstDest!ContractType = objSourcePrice.Заказ.Вид
            '    rstDest!DovSer = Trim(objSourcePrice.ДовСерия)
            '    rstDest!DovNumb = Trim(objSourcePrice.ДовНомер)
            '    rstDest!DovDate = objSourcePrice.ДовДата
            '    rstDest!DovFIO = Trim(objSourcePrice.Получил)
            '    rstDest!BankID = Trim(objSourcePrice.Касса.ПолныйКод())
            '    rstDest!DoxRasx = Trim(objSourcePrice.СубконтоВалДох.ПолныйКод())
            '    rstDest!BeginDate = dBeg
            '    rstDest!EndDate = dEnd

            '    If objSourcePrice.IsTransacted() = 1 Then
            '        rstDest!IsTrans = True
            '    Else
            '        rstDest!IsTrans = False
            '    End If
            '    '   rstDest!ChekTotal = objSourcePrice.БазаНДС
            '    rstDest!Cash = objSourcePrice.ВидТорговли.Идентификатор
            _SQLiteBillProvider.InsertBill(_Bill)
            '    objSourcePrice.ВыбратьСтроки
            While objSourcePrice.ПолучитьСтроку() > 0
                Console.WriteLine("Stock " & objSourcePrice.ТМЦ.Наименование & " - " & objSourcePrice.Кво)
                '        rstDestDet.AddNew
                _BillLine.OrderGuid = objSourcePrice.НомерДок
                '        rstDestDet!CheckType = objSourcePrice.Вид()
                '        rstDestDet!Division = objSourcePrice.Участок.Наименование
                '        rstDestDet!CheckStorID = objSourcePrice.МестоХранения.Наименование
                _BillLine.StockCounter = objSourcePrice.ТМЦ.Код
                '        rstDestDet!CodeZvit = objSourcePrice.ТМЦ.CodeZvit
                _BillLine.Stock = objSourcePrice.ТМЦ.Наименование
                '        rstDestDet!Group = objSourcePrice.ТМЦ.Родитель.Наименование
                _BillLine.Quatity = objSourcePrice.Кво
                '        rstDestDet!CheckPrice = objSourcePrice.ЦенаБезНДС
                '        rstDestDet!ResSum = objSourcePrice.СуммаСНДС
                '        rstDestDet!ResSum281 = objSourcePrice.СуммаБезНДС
                '        rstDestDet!PDV = objSourcePrice.НДС
                '        rstDestDet!ValueForCount = objSourcePrice.Ед.Ед.Идентификатор
                '        rstDestDet!ValueForCountID = objSourcePrice.Ед.ПолныйКод

                '        rstDestDet!CodeMgr = objSourcePrice.ТМЦ.Макрогруппа.Код

                '        rstDestDet!Cost = objSourcePrice.Cost
                '        rstDestDet!ResCost = objSourcePrice.Cost * objSourcePrice.Кво
                '        If (objSourcePrice.ТМЦ.Родитель.Наименование <> "Аренда") Then
                '            rstDestDet!MergeFromCost = objSourcePrice.СуммаБезНДС - objSourcePrice.Cost * objSourcePrice.Кво
                '        Else
                '            rstDestDet!MergeFromCost = objSourcePrice.СуммаБезНДС
                '        End If

                '        Debug.Print objSourcePrice.Ед.ПолныйКод
                '    'Debug.Print objSourcePrice.БазЕдиница.ПорядковыйНомер()

                '        '   If objSourcePrice.ТМЦ.Код = "01336" Then
                '        '   Debug.Print objSourcePrice.ТМЦ.Счет.Код
                '        '   End If
                '        If (objSourcePrice.Партия.Наименование = "Партия по умолчанию") _
                '                And objSourcePrice.ТМЦ.Счет.Код Then
                '            '   Debug.Print objSourcePrice.ТМЦ.Код
                '            strSQL = "SELECT RestIn.StorID, RestIn.StorName, RestIn.StockID, Sum(RestIn.Qty) AS Qty, Sum(RestIn.Summ) AS Summ "
                '            strSQL = strSQL & "FROM RestIn "
                '            strSQL = strSQL & "GROUP BY RestIn.StorID, RestIn.StorName, RestIn.StockID "
                '            strSQL = strSQL & "HAVING ((RestIn.StockID)='" & objSourcePrice.ТМЦ.Код & "'); "
                '        '   strSQL = strSQL & "HAVING (((RestIn.StorName)='" & objSourcePrice.МестоХранения.Наименование & "') AND ((RestIn.StockID)='" & objSourcePrice.ТМЦ.Код & "')); "
                '        Set rstRest = dbs.OpenRecordset(strSQL)
                '        '   Debug.Print strSQL
                '        If rstRest.EOF() And rstRest.BOF Then
                '                rstDestDet!ResSum902 = 0
                '                rstDestDet!Comment = "Умолчание без себестоимости"
                '            Else
                '                rstDestDet!ResSum902 = rstRest!Summ / rstRest!Qty * objSourcePrice.Кво
                '            End If
                '        Else
                '            rstDestDet!ResSum902 = objSourcePrice.Партия.Цена_Прих * objSourcePrice.Кво
                '        End If
                '        rstDestDet!Contract = objSourcePrice.Заказ.НомерДок
                '        rstDestDet!StatNalDek = objSourcePrice.ТМЦ.ВидЗатрат.СтатьяНалоговойДекларации.Наименование
                '        rstDestDet!PartOfStockID = objSourcePrice.Партия.Код
                '        rstDestDet!PartOfStockFullID = objSourcePrice.Партия.ПолныйКод()
                '        rstDestDet!PartOfStock = objSourcePrice.Партия.Наименование
                _SQLiteBillProvider.InsertBillLine(_BillLine)
            End While

        End While
    End Sub
End Class
