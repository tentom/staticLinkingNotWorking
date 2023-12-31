﻿using System;
using Foundation;
using ObjCRuntime;

namespace Movesense {

    // The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
    // to the project.
    // Open your binding csproj and add a section like this
    // <ItemGroup>
    //   <NativeReference Include="MyLibrary.xcframework">
    //     <Kind>Framework</Kind>
    //     <Frameworks></Frameworks>
    //   </NativeReference>
    // </ItemGroup>
    //
    // Once you've added it, you will need to customize it for your specific library:
    //  - Change the Include to the correct path/name of your library
    //  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
    //    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
    //  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
    // Example:
    // <NativeReference Include="libs\MyTestFramework.xcframework">
    //   <Kind>Framework</Kind>
    //   <Frameworks>CoreLocation ModelIO</Frameworks>
    // </NativeReference>
    // 
    // Once you've done that, you're ready to move on to binding the API...
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, nint index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     NativeHandle Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MovesenseServiceUUID;
        [Field("MovesenseServiceUUID", "__Internal")]
        NSString MovesenseServiceUUID { get; }
    }

    // @interface MDSResponse : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSResponse
    {
        // @property (readonly, nonatomic) NSDictionary * _Nonnull header;
        [Export("header")]
        NSDictionary Header { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull bodyData;
        [Export("bodyData")]
        NSData BodyData { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nullable bodyDictionary;
        [NullAllowed, Export("bodyDictionary")]
        NSDictionary BodyDictionary { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull contentType;
        [Export("contentType")]
        string ContentType { get; }

        // @property (readonly, nonatomic) NSInteger statusCode;
        [Export("statusCode")]
        nint StatusCode { get; }

        // @property (readonly, nonatomic) MDSResponseMethod method;
        [Export("method")]
        MDSResponseMethod Method { get; }

        // -(NSData * _Nonnull)getStreamData;
        [Export("getStreamData")]
        NSData StreamData { get; }
    }

    // typedef void (^MDSResponseBlock)(MDSResponse * _Nonnull);
    public delegate void MDSResponseBlock(MDSResponse arg0);

    // @interface MDSEvent : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSEvent
    {
        // @property (readonly, nonatomic) NSDictionary * _Nonnull header;
        [Export("header")]
        NSDictionary Header { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull bodyData;
        [Export("bodyData")]
        NSData BodyData { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nullable bodyDictionary;
        [NullAllowed, Export("bodyDictionary")]
        NSDictionary BodyDictionary { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull contentType;
        [Export("contentType")]
        string ContentType { get; }
    }

    // typedef void (^MDSEventBlock)(MDSEvent * _Nonnull);
    public delegate void MDSEventBlock(MDSEvent arg0);

    // @interface MDSTunnelResponse : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSTunnelResponse
    {
        // @property (readonly, nonatomic) NSInteger status;
        [Export("status")]
        nint Status { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull response;
        [Export("response")]
        string Response { get; }

        // -(instancetype _Nonnull)initWithStatus:(NSInteger)status response:(NSString * _Nonnull)response;
        [Export("initWithStatus:response:")]
        IntPtr Constructor(nint status, string response);
    }

    // @interface MDSTunnelRequest : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSTunnelRequest
    {
        // @property (readonly, nonatomic) NSDictionary * _Nonnull header;
        [Export("header")]
        NSDictionary Header { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull bodyData;
        [Export("bodyData")]
        NSData BodyData { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nullable bodyDictionary;
        [NullAllowed, Export("bodyDictionary")]
        NSDictionary BodyDictionary { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull contentType;
        [Export("contentType")]
        string ContentType { get; }
    }

    // typedef MDSTunnelResponse * _Nullable (^MDSTunnelRequestBlock)(MDSTunnelRequest * _Nonnull);
    public delegate MDSTunnelResponse MDSTunnelRequestBlock(MDSTunnelRequest arg0);

    // @interface MDSResourceRequestResponse : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSResourceRequestResponse
    {
        // @property (readonly, nonatomic) NSInteger status;
        [Export("status")]
        nint Status { get; }

        // @property (readonly, nonatomic) BOOL isStream;
        [Export("isStream")]
        bool IsStream { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull response;
        [Export("response")]
        NSData Response { get; }

        // -(instancetype _Nonnull)initWithStatus:(NSInteger)status message:(NSString * _Nonnull)response;
        [Export("initWithStatus:message:")]
        IntPtr Constructor(nint status, string response);

        // -(instancetype _Nonnull)initWithStatus:(NSInteger)status streamData:(NSData * _Nonnull)response;
        [Export("initWithStatus:streamData:")]
        IntPtr Constructor(nint status, NSData response);
    }

    // @interface MDSResourceRequest : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSResourceRequest
    {
        // @property (readonly, nonatomic) MDSRequestMethod method;
        [Export("method")]
        MDSRequestMethod Method { get; }
        // @property (readonly, nonatomic) NSDictionary * _Nonnull header;
        [Export("header")]
        NSDictionary Header { get; }

        // @property (readonly, nonatomic) NSString * _Nonnull contentType;
        [Export("contentType")]
        string ContentType { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull bodyData;
        [Export("bodyData")]
        NSData BodyData { get; }

        // @property (readonly, nonatomic) NSData * _Nonnull streamData;
        [Export("streamData")]
        NSData StreamData { get; }

        // @property (readonly, nonatomic) NSDictionary * _Nullable bodyDictionary;
        [NullAllowed, Export("bodyDictionary")]
        NSDictionary BodyDictionary { get; }
    }

    // typedef MDSResourceRequestResponse * _Nullable (^MDSResourceRequestBlock)(MDSResourceRequest * _Nonnull);
    public delegate MDSResourceRequestResponse MDSResourceRequestBlock(MDSResourceRequest arg0);

    // @protocol MDSConnectivityServiceDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    public interface MDSConnectivityServiceDelegate
    {
        // @optional -(void)didFailToConnectWithError:(const NSError * _Nonnull)error;
        [Export("didFailToConnectWithError:")]
        void DidFailToConnectWithError(NSError error);
    }

    // @interface MDSWrapper : NSObject
    [BaseType(typeof(NSObject))]
    public interface MDSWrapper
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MDSConnectivityServiceDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MDSConnectivityServiceDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(instancetype _Nonnull)init:(NSBundle * _Nonnull)configBundle;
        [Export("init:")]
        IntPtr Constructor(NSBundle configBundle);

        // -(void)connectPeripheralWithUUID:(NSUUID * _Nonnull)uuid;
        [Export("connectPeripheralWithUUID:")]
        void ConnectPeripheralWithUUID(NSUuid uuid);

        // -(BOOL)disconnectPeripheralWithUUID:(NSUUID * _Nonnull)uuid;
        [Export("disconnectPeripheralWithUUID:")]
        bool DisconnectPeripheralWithUUID(NSUuid uuid);

        // -(void)disableAutoReconnectForDeviceWithUUID:(NSUUID * _Nonnull)uuid;
        [Export("disableAutoReconnectForDeviceWithUUID:")]
        void DisableAutoReconnectForDeviceWithUUID(NSUuid uuid);

        // -(void)disableAutoReconnectForDeviceWithSerial:(NSString * _Nonnull)serial;
        [Export("disableAutoReconnectForDeviceWithSerial:")]
        void DisableAutoReconnectForDeviceWithSerial(string serial);

        // -(void)doSubscribe:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract response:(MDSResponseBlock _Nonnull)response onEvent:(MDSEventBlock _Nonnull)onEvent;
        [Export("doSubscribe:contract:response:onEvent:")]
        void DoSubscribe(string resourcePath, NSDictionary contract, MDSResponseBlock response, MDSEventBlock onEvent);

        // -(void)doUpdateSubscription:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract completion:(MDSResponseBlock _Nonnull)completion;
        [Export("doUpdateSubscription:contract:completion:")]
        void DoUpdateSubscription(string resourcePath, NSDictionary contract, MDSResponseBlock completion);

        // -(void)doUnsubscribe:(NSString * _Nonnull)resourcePath;
        [Export("doUnsubscribe:")]
        void DoUnsubscribe(string resourcePath);

        // -(void)doRegisterResource:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract response:(MDSResponseBlock _Nonnull)response onRequest:(MDSTunnelRequestBlock _Nonnull)onRequest;
        [Export("doRegisterResource:contract:response:onRequest:")]
        void DoRegisterResource(string resourcePath, NSDictionary contract, MDSResponseBlock response, MDSTunnelRequestBlock onRequest);

        // -(void)doRegisterResource:(NSURL * _Nonnull)resourceMetadataBinary response:(MDSResponseBlock _Nonnull)response onRequest:(MDSResourceRequestBlock _Nonnull)onRequest;
        [Export("doRegisterResource:response:onRequest:")]
        void DoRegisterResource(NSUrl resourceMetadataBinary, MDSResponseBlock response, MDSResourceRequestBlock onRequest);

        // -(void)doUnregisterResource:(NSURL * _Nonnull)resourceMetadataBinary response:(MDSResponseBlock _Nonnull)response;
        [Export("doUnregisterResource:response:")]
        void DoUnregisterResource(NSUrl resourceMetadataBinary, MDSResponseBlock response);

        // -(void)doSendResourceNotification:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract;
        [Export("doSendResourceNotification:contract:")]
        void DoSendResourceNotification(string resourcePath, NSDictionary contract);

        // -(void)doGet:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract completion:(MDSResponseBlock _Nonnull)completion;
        [Export("doGet:contract:completion:")]
        void DoGet(string resourcePath, NSDictionary contract, MDSResponseBlock completion);

        // -(void)doPut:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract completion:(MDSResponseBlock _Nonnull)completion;
        [Export("doPut:contract:completion:")]
        void DoPut(string resourcePath, NSDictionary contract, MDSResponseBlock completion);

        // -(void)doPost:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract completion:(MDSResponseBlock _Nonnull)completion;
        [Export("doPost:contract:completion:")]
        void DoPost(string resourcePath, NSDictionary contract, MDSResponseBlock completion);

        // -(void)doDelete:(NSString * _Nonnull)resourcePath contract:(NSDictionary * _Nonnull)contract completion:(MDSResponseBlock _Nonnull)completion;
        [Export("doDelete:contract:completion:")]
        void DoDelete(string resourcePath, NSDictionary contract, MDSResponseBlock completion);

        // -(void)deactivate;
        [Export("deactivate")]
        void Deactivate();
    }


}


