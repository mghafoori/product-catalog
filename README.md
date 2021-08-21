# Product Catalog Sample Project

There is an issue in the `ProductCatalog.ClientConsole` project, specifically in the `Program.cs` file, line 23:

```
if (await prodCreator.CreateAsync())
```

It seems that the asynchronous operation is not completed before the console ends. 

How can it be fixed?

### Hints

* File `AbstractEntityCreator.cs` lines 44 to 47 is where we invoke the event's subscribers, but we do not `await` them:

    ```
    if (OnSuccess != null)
    {
        OnSuccess.Invoke();
    }
    ```

* File `Program.cs` line 15 is where we define an `async` delegate of type `Action`:

    ```
    catCreator.OnSuccess += async () =>
    ```
