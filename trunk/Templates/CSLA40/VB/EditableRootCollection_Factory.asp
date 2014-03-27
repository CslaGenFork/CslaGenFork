        #Region " Factory Methods "
<%
bool createRunLocal = false;
bool createNonLocal = false;
bool getRunLocal = false;
bool getNonLocal = false;
foreach (Criteria c in Info.CriteriaObjects)
{
    if (c.CreateOptions.Factory)
    {
        createRunLocal = createRunLocal || c.CreateOptions.RunLocal;
        createNonLocal = createNonLocal || !c.CreateOptions.RunLocal;
    }
    if (c.GetOptions.Factory)
    {
        getRunLocal = getRunLocal || c.GetOptions.RunLocal;
        getNonLocal = getNonLocal || !c.GetOptions.RunLocal;
    }
}
bool createRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (createRunLocal || createNonLocal) && !useUnitOfWorkCreator;
bool getRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (getRunLocal || getNonLocal) && !useUnitOfWorkGetter;
createRunLocal = createRunLocal && !useUnitOfWorkCreator;
createNonLocal = createNonLocal || useUnitOfWorkCreator;
getRunLocal = getRunLocal && !useUnitOfWorkGetter;
getNonLocal = getNonLocal || useUnitOfWorkGetter;
bool localMethodsExists = createRunLocal || getRunLocal;
bool localSilverlightMethodsExists = createRunLocalSilverlight || getRunLocalSilverlight;
bool nonLocalMethodsExists = createNonLocal || getNonLocal;
bool asyncSilverlightIsDifferent = UseBoth() && (localMethodsExists || localSilverlightMethodsExists);
bool silverlightIsDifferent = asyncSilverlightIsDifferent ||
    (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous);
bool silverlightServicesAlone = CurrentUnit.GenerationParams.SilverlightUsingServices && !UseNoSilverlight();

if (silverlightIsDifferent)
{
    %>

#If Not SILVERLIGHT Then
<%
}
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="GetObject.asp" -->
<%
if (CurrentUnit.GenerationParams.GenerateAsynchronous && (!UseSilverlight() || localMethodsExists || localSilverlightMethodsExists))
{
    if (Info.HasCreateCriteriaFactory && (!UseSilverlight() || createRunLocal || createRunLocalSilverlight))
    {
        createGenerateLocal = true;
        forceGeneration = null;
        if (!UseSilverlight() || createRunLocalSilverlight)
            forceGeneration = true;
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
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
    if (HasFactoryCreateOrGetOrDelete(Info) &&
        (asyncSilverlightIsDifferent || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !localSilverlightMethodsExists)))
    {
        %>

#Else
<%
        if (createRunLocal || createRunLocalSilverlight || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !createRunLocalSilverlight))
        {
            %>
<!-- #include file="NewObjectSilverlight.asp" -->
<%
        }
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
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<%
}
if (CurrentUnit.GenerationParams.GenerateAsynchronous && UseBoth())
{
    if (createNonLocal && !createRunLocalSilverlight)
    {
        createGenerateLocal = false;
        forceGeneration = null;
        %>
<!-- #include file="NewObjectAsync.asp" -->
<%
    }
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
