<%
CslaObjectInfo parentInfo = Info.Parent.CslaObjects.Find(Info.ParentType);
CslaObjectInfo itemInfo = FindChildInfo(Info, Info.ItemType);
UseChildFactoryHelper = CurrentUnit.GenerationParams.UseChildFactory;
bool isChild = parentInfo != null;
%>
