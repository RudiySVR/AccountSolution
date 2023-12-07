Imports AccountSolution.FromAccountClassLibrary.Entities
Imports AccountSolution.FromAccountClassLibrary.MSAccessClient
Imports AccountSolution.SqliteClassLibrary

Public Class Price
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

    Public Sub ShortPriceMove()
        'Dim _ShortPriceTableAdapter As ShortPriceTableAdapter = New ShortPriceTableAdapter
        Dim _ShortPrice As ShortPrice = New ShortPrice
        objSourcePrice = objSource.CreateObject("Справочник.КороткийПрайс")
        Dim _PriceLite As SqlitePriceProvider = New SqlitePriceProvider
        _PriceLite.DeleteShortPriceAll()
        '_ShortPriceTableAdapter.DeleteQueryAll()
        objSourcePrice.ВыбратьЭлементы()
        While objSourcePrice.ПолучитьЭлемент() = 1
            Console.WriteLine(objSourcePrice.Код & "|" & objSourcePrice.Наименование)
            If objSourcePrice.ЭтоГруппа() <> 1 Then
                'Console.WriteLine(objSourcePrice.Код & "|" & objSourcePrice.Наименование)
                'Debug.Print(objSourcePrice.Код & "|" & objSourcePrice.Наименование)
                'rstDest.AddNew()
                _ShortPrice.StockPriceGroupeID = objSourcePrice.Код
                ''rstDest![FullStockPriceGroupeID] = objSourcePrice.ПолныйКод
                'rstDest![FullStockPriceGroupeID] = objSourcePrice.Родитель.Код
                'rstDest![OldID] = objSourcePrice.КодИзСклада
                _ShortPrice.StockGroupe = objSourcePrice.Наименование
                'rstDest![IsPrint] = objSourcePrice.Печать
                _ShortPrice.ValueForCount = objSourcePrice.ЕдИзм
                _ShortPrice.Base = objSourcePrice.БазоваяЦена
                _ShortPrice.Second = objSourcePrice.ВтЦена
                _ShortPrice.Third = objSourcePrice.ТрЦена
                'rstDest![Fourth] = objSourcePrice.ЧтЦена
                _ShortPrice.BasePDV = objSourcePrice.БазоваяЦенаНДС
                _ShortPrice.SecondPDV = objSourcePrice.ВтЦенаНДС
                _ShortPrice.ThirdPDV = objSourcePrice.ТрЦенаНДС
                'rstDest![FourthPDV] = objSourcePrice.ЧтЦенаНДС
                'rstDest![FifthPDV] = objSourcePrice.ПтЦенаНДС
                'rstDest![Fifth] = objSourcePrice.ПтЦена
                'rstDest![Lable] = objSourcePrice.Этикетка
                'Debug.Print(objSourcePrice.Печать)
                ''rstDest![PrintValue] = objSourcePrice.Печать
                'rstDest.Update()
                'Debug.Print objSourcePrice.Наименование
                '_ShortPriceTableAdapter.InsertQuerySample(Convert.ToInt16(objSourcePrice.Код), objSourcePrice.Наименование, 1, 0, 0,
                '                                              objSourcePrice.ЕдИзм, CSng(objSourcePrice.БазоваяЦенаНДС),
                '                                              CSng(objSourcePrice.ВтЦенаНДС), CSng(objSourcePrice.ТрЦенаНДС),
                '                                              CSng(objSourcePrice.БазоваяЦена))
                '_ShortPriceTableAdapter.InsertQuerySample(0, objSourcePrice.Наименование, 1, 0, 0, objSourcePrice.ЕдИзм)
                _PriceLite.InsertShortPrice(_ShortPrice)
            End If
        End While
    End Sub

    Public Sub MoveDetPrice()
        Dim _PriceGroup As PriceGroup = New PriceGroup
        Dim _Price As FromAccountClassLibrary.Entities.Price = New FromAccountClassLibrary.Entities.Price
        Dim _PriceLite As SqlitePriceProvider = New SqlitePriceProvider
        Dim _AccessPriceProvider As AccessPriceProvider = New AccessPriceProvider
        objSourcePrice = objSource.CreateObject("Справочник.ТМЦ")
        'SQLitePCL.raw.SetProvider(New SQLitePCL.SQLite3Provider_e_sqlite3())
        'SQLitePCL.Batteries.Init()
        _PriceLite.DeletePriceAll()
        _PriceLite.DeletePriceGroupAll()

        objSourcePrice.ВыбратьЭлементы()
        While objSourcePrice.ПолучитьЭлемент() = 1
            '   If ((objSourcePrice.ЭтоГруппа() = 0) And ((objSourcePrice.Счет.Код = "281"))) Then
            If (objSourcePrice.ЭтоГруппа() = 1) And objSourcePrice.Внет = 1 Then
                _PriceGroup.GroupID = objSourcePrice.Код
                _PriceGroup.GroupName = objSourcePrice.Наименование
                _PriceGroup.ParentID = objSourcePrice.Родитель.Код
                _PriceGroup.ParentName = objSourcePrice.Родитель.Наименование
                _PriceGroup.Path = objSourcePrice.Лого
                _PriceGroup.Pict = objSourcePrice.Лого
                _PriceGroup.Internet = IIf(objSourcePrice.Внет = 1, True, False)
                '_AccessPriceProvider.InsertPriceGroup(_PriceGroup)
                Try
                    _PriceLite.InsertPriceGroup(_PriceGroup)
                Catch ex As Exception
                    Console.WriteLine(ex.Message)
                End Try
                'Console.WriteLine(objSourcePrice.Код & " | " & objSourcePrice.Наименование)
            Else
                If (((objSourcePrice.Счет.Код = "84") Or (objSourcePrice.Счет.Код = "281") Or (objSourcePrice.Счет.Код = "26")) And objSourcePrice.Родитель.Внет = 1) Then
                    'rstDest.AddNew()
                    _Price.StockCounter = objSourcePrice.Код
                    'rstDest![AutoKoef] = objSource.Константа.КоэффТоп
                    'rstDest![CutKoef] = objSource.Константа.КоэффПропан
                    'rstDest![BarCode] = objSourcePrice.BarCode
                    'rstDest![BarCodeString] = objSourcePrice.BarCodeString
                    'rstDest![OldID] = objSourcePrice.КодИзСклада
                    _Price.Stock = objSourcePrice.Наименование
                    _Price.NumbGroup = objSourcePrice.Родитель.Код
                    _Price.FullName = objSourcePrice.ПолнНаименование
                    'rstDest![GroupNameRus] = objSourcePrice.НаименованиеРусское
                    'rstDest![GroupNameEng] = objSourcePrice.НаименованиеАнгл
                    'rstDest![Logo] = objSourcePrice.Лого
                    'rstDest![Internet] = IIf(objSourcePrice.Внет = 1, True, False)
                    If objSourcePrice.ПометкаУдаления() = 1 Then
                        'rstDest!blIsDel = True
                    Else
                        'rstDest!blIsDel = False
                    End If
                    'rstDest![Logo] = objSourcePrice.ЛВнет
                    If (Len(objSourcePrice.СпрЦен.Код) <> 0) Then
                        _Price.StockPriceGroupeID = objSourcePrice.СпрЦен.Код
                    End If
                    _Price.CountForPack = objSourcePrice.ВесМетра
                    'rstDest![TeorVes] = objSourcePrice.Теорвес
                    _Price.ValueForCount = objSourcePrice.БазЕдиница.Идентификатор           '
                    'rstDest![NumbValueForCount] = objSourcePrice.БазЕдиница.ПорядковыйНомер     '
                    'rstDest![ReportID] = objSourcePrice.CodeZvit    '
                    _Price.PriceForCount = objSourcePrice.СпрЦен.БазоваяЦенаНДС
                    '_Price.PriceForCount = objSourcePrice.Цена_Прод    '

                    'rstDest![AccStockID] = objSourcePrice.Счет.Код
                    'rstDest![AccStockIDZatr] = objSourcePrice.СчетЗатрат.Код
                    'rstDest![NumbMacGroup] = objSourcePrice.Макрогруппа.Код

                    _Price.Character = objSourcePrice.Характеристика
                    'rstDest![PDV_ID] = objSourcePrice.СтавкаНДС.Код
                    'rstDest![OldID] = objSourcePrice.КодИзСклада
                    'rstDest![TMC_Numb] = objSourcePrice.ВидТМЦ.ПорядковыйНомер()
                    'rstDest![TMC_Name] = objSourcePrice.ВидТМЦ.Идентификатор()
                    'rstDest![WidthPoll] = objSourcePrice.Ширина

                    If (Len(objSourcePrice.ВидЗатрат.Код) <> 0) Then
                        'rstDest![CostID] = objSourcePrice.ВидЗатрат.Код
                        'rstDest![CostName] = objSourcePrice.ВидЗатрат.Наименование
                    End If
                    If (Len(objSourcePrice.ВидДеятельности.Код) <> 0) Then
                        'rstDest![KindWorkID] = objSourcePrice.ВидДеятельности.Код
                        'rstDest![KindWorkName] = objSourcePrice.ВидДеятельности.Наименование
                    End If
                    'rstDest.Update()
                    '_AccessPriceProvider.InsertPrice(_Price)
                    Try
                        _PriceLite.InsertPrice(_Price)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                    Console.WriteLine(objSourcePrice.Код & " | " & objSourcePrice.Наименование & " | " & objSourcePrice.СпрЦен.БазоваяЦенаНДС)
                End If
            End If
        End While
    End Sub

End Class
