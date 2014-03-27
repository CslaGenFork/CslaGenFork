        #region Factory Methods
<%
bool createRunLocal = false;
bool createNonLocal = false;
bool getRunLocal = false;
bool getNonLocal = false;
bool deleteRunLocal = false;
bool deleteNonLocal = false;
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
    if (c.DeleteOptions.Factory)
    {
        deleteRunLocal = deleteRunLocal || c.DeleteOptions.RunLocal;
        deleteNonLocal = deleteNonLocal || !c.DeleteOptions.RunLocal;
    }
}
bool createRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (createRunLocal || createNonLocal) && !useUnitOfWorkCreator;
bool getRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (getRunLocal || getNonLocal) && !useUnitOfWorkGetter;
bool deleteRunLocalSilverlight = CurrentUnit.GenerationParams.SilverlightUsingServices && (deleteRunLocal || deleteNonLocal);
createRunLocal = createRunLocal && !useUnitOfWorkCreator;
createNonLocal = createNonLocal || useUnitOfWorkCreator;
getRunLocal = getRunLocal && !useUnitOfWorkGetter;
getNonLocal = getNonLocal || useUnitOfWorkGetter;
bool localMethodsExists = createRunLocal || getRunLocal || deleteRunLocal;
bool localSilverlightMethodsExists = createRunLocalSilverlight || getRunLocalSilverlight || deleteRunLocalSilverlight;
bool nonLocalMethodsExists = createNonLocal || getNonLocal || deleteNonLocal;
bool asyncSilverlightIsDifferent = UseBoth() && (localMethodsExists || localSilverlightMethodsExists);
bool silverlightIsDifferent = asyncSilverlightIsDifferent ||
    (UseBoth() && CurrentUnit.GenerationParams.GenerateSynchronous);
bool silverlightServicesAlone = CurrentUnit.GenerationParams.SilverlightUsingServices && !UseNoSilverlight();

if (silverlightIsDifferent)
{
    %>

#if !SILVERLIGHT
<%
}
%>
<!-- #include file="NewObject.asp" -->
<!-- #include file="GetObject.asp" -->
<!-- #include file="DeleteObject.asp" -->
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
    if (Info.HasDeleteCriteriaFactory && (!UseSilverlight() || deleteRunLocal || deleteRunLocalSilverlight))
    {
        generateLocal = true;
        forceGeneration = null;
        if (!UseSilverlight() || deleteRunLocalSilverlight)
            forceGeneration = true;
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
if (silverlightIsDifferent)
{
    if (HasFactoryCreateOrGetOrDelete(Info) &&
        (asyncSilverlightIsDifferent || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !localSilverlightMethodsExists)))
    {
        %>

#else
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
        if (deleteRunLocal || deleteRunLocalSilverlight || (!CurrentUnit.GenerationParams.GenerateAsynchronous && !deleteRunLocalSilverlight))
        {
            %>
<!-- #include file="DeleteObjectSilverlight.asp" -->
<%
        }
    }
    %>

#endif
<%
}
else if (silverlightServicesAlone)
{
    %>
<!-- #include file="NewObjectSilverlight.asp" -->
<!-- #include file="GetObjectSilverlight.asp" -->
<!-- #include file="DeleteObjectSilverlight.asp" -->
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
    if (deleteNonLocal && !deleteRunLocalSilverlight)
    {
        generateLocal = false;
        forceGeneration = null;
        %>
<!-- #include file="DeleteObjectAsync.asp" -->
<%
    }
}
%>

        #endregion
