        #Region " Factory Methods "
<%
bool getRunLocal = false;
bool getNonLocal = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.GetOptions.Factory)
    {
        getRunLocal = getRunLocal || c.GetOptions.RunLocal;
        getNonLocal = getNonLocal || !c.GetOptions.RunLocal;
    }
}
bool getRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (getRunLocal || getNonLocal) && !useUnitOfWorkGetter;
getRunLocal = getRunLocal && !useUnitOfWorkGetter;
getNonLocal = getNonLocal || useUnitOfWorkGetter;
bool internalGetObjectUsed = false;
if (parentInfo != null)
    internalGetObjectUsed = !Info.HasGetCriteriaFactory && !IsChildSelfLoaded(parentInfo);
bool localMethodsExists = getRunLocal;
bool nonLocalMethodsExists = getNonLocal;
bool localSilverlightMethodsExists = getRunLocalSilverlight;
bool asyncSilverlightIsDifferent = UseBoth() && (localMethodsExists || localSilverlightMethodsExists);
bool silverlightIsDifferent = asyncSilverlightIsDifferent ||
    (UseBoth() && (CurrentUnit.GenerationParams.GenerateSynchronous || internalGetObjectUsed));
bool silverlightServicesAlone = CurrentUnit.GenerationParams.SilverlightUsingServices && !UseNoSilverlight();

if (silverlightIsDifferent)
{
    %>

#If Not SILVERLIGHT Then
<%
}
if (UseNoSilverlight())
{
    %>
<!-- #include file="InternalGetObject.asp" -->
<%
}
%>
<!-- #include file="GetObject.asp" -->
<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous && (!UseSilverlight() || localMethodsExists || localSilverlightMethodsExists))
{
    if (Info.HasGetCriteriaFactory && (!UseSilverlight() || getRunLocal || getRunLocalSilverlight))
    {
        generateLocal = true;
        forceGeneration = null;
        if (!UseSilverlight() || getRunLocalSilverlight)
            forceGeneration = true;
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
if (silverlightIsDifferent)
{
    if (Info.HasGetCriteriaFactory &&
        (asyncSilverlightIsDifferent || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !localSilverlightMethodsExists)))
    {
        %>

#Else
<%
        if (getRunLocal || getRunLocalSilverlight || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !getRunLocalSilverlight))
        {
            %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
        }
    }
    %>

#End If
<%
}
else if (silverlightServicesAlone)
{
    %>
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && UseBoth())
{
    if (getNonLocal && !getRunLocalSilverlight)
    {
        generateLocal = false;
        forceGeneration = null;
        %>
<!-- #include file="GetObjectAsync.asp" -->
<%
    }
}
%>

        #End Region
