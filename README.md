CslaGenFork
===

![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Logos/Project-Logo-final.gif)

O/RM code generator for CSLA.NET 4.3/4.5/4.6 generating Stored Procedures, Business Layer and Data Access Layer code for Windows Forms, ASP.NET, WPF and Silverlight.
There is a complete set of C# templates. Currently there are VB templates, but only for non DAL architecture. You are welcome to contribute with VB templates for DAL DataReader and DAL using DTO.

# 2017 Mar 01 - Version 4.6.0 released ![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_star.png)

This release brings a lot of new features and some usability improvements. It's available at [CslaGenFork release 4.6.0](https://github.com/CslaGenFork/CslaGenFork/releases/tag/v4.6.0)

## Fixes and new features

1. Besides SQL Server, code generation can target other database engines.

2. Numerous fixes to VB code generation

3. New kinds of CslaObject: abstract base classes, custom criteria classes (wip). The *place holder* is a nice feature that can be used to group objects (in light blue)

![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_CGF-PlaceHolder.png)

4. Improved property handling with support for custom types (enums etc), database unbound properties and properties persisted to the database as null (read and WRITE)

5. Much improved inheritance support

6. Handle the Saved static event raised by EditableRoot with Weak Event (the generated code was causing memory leaks)

7. Improved database type handling (doesn't crash on geography, etc)

8. The "rules from DLL" feature supports rules with generic type parameters.

### UI improvements

- Improve Enum's display - for instance, show **Editable Child Collection** instead of **EditableChildCollection** or show **C#** instead of **CSharp**
- Improve UI field hiding (show only UI fields that make sense)
- Improve type filtering (show only objects/properties that make sense).
- Introduce **Don't ask again** MessageBoxEx control and apply it where it fits.

## Breaking changes

The incomplete feature **Generate BypassPropertyChecks** was dropped.
Dropped legacy support: pre CSLA .NET 4.0 projects, active objects and plugin system.

Other projects
---
2017 Sep 04 - Rules sample moved to CslaContrib ![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_star.png)
- The rules in CslaGenFork library were added to [CslaContrib library](https://github.com/MarimerLLC/cslacontrib);
- They are available on NuGet as **CslaContrib**

Get started
---
### [Useful links](https://github.com/CslaGenFork/CslaGenFork/wiki/Useful-links)

Browse forums, product sites, manuals and samples.

### [Is code generation a good idea?](https://github.com/CslaGenFork/CslaGenFork/wiki/Code-generation-is-a-good-idea)

If you were told generated code is bug ridden or rigid or code gen tools are just toys, then have a second opinion.

### [Why would I use CslaGenFork?](https://github.com/CslaGenFork/CslaGenFork/wiki/Why-use-CslaGenFork)

If you had some bad experiences with CslaGen or other code gen tools, then you don't need a feature list but an argument list.

### [How do I use CslaGenFork?] (*link is missing...*)

No, you are not sent out to the wild on your own. We try to help all the way. Or at least, some of the way...
- How do I start using it?
- How do I organize myself?
- Do I need some tools?
- Where do I fetch the free CodeSmith engine?
- Is there a suggested workflow for codegen?

### 2011 Jul 02 - Cheat Sheet contents includes: (*link is missing...*)

How to create objects and collections by point and click
How to create child objects and child collections by point and click
What are those dreaded Parent Properties
How to use DataAnnotations validation rules

### Is there a FAQ?

Of course there is! It's brand new and it's a moving target meaning I'm adding questions every now and then.
Read it here  (*link is missing...*)

Miscelaneous
---

### About the license

CslaGenFork is GPL 2. This means you can use the generated code as you like: sell, borrow, lend or even give away.

### Acknowledgements

CslaGen couldn't exist without the free CodeSmith DLL. Great care was taken in not breaching the CodeSmith license agreement neither by CslaGenFork nor by anyone using it, Thank you CodeSmith.


![](https://raw.github.com/CslaGenFork/CslaGenFork/master/Support/Home/Home_ReSharper.png)
