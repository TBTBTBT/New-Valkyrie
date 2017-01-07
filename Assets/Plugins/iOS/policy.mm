/*
 appstoreの審査システムは遅くて適当
 */
extern "C"
{
int retback = 0;
extern UIViewController* UnityGetGLViewController();
int ViewFkinPolicy(){
    // コントローラを生成
    retback = -1;
    UIAlertController * ac =
    [UIAlertController alertControllerWithTitle:@"プライバシーポリシー"
                                        message:@"ランキングに登録します。\n\nプライバシーポリシー\nhttp://www.apple.com/legal/privacy/"
                                 preferredStyle:UIAlertControllerStyleAlert];
    
    // Cancel用のアクションを生成
    UIAlertAction * cancelAction =
    [UIAlertAction actionWithTitle:@"Cancel"
                             style:UIAlertActionStyleCancel
                           handler:^(UIAlertAction * action) {
                               // ボタンタップ時の処理
                               retback = 0;
                           }];
    
    // OK用のアクションを生成
    UIAlertAction * okAction =
    [UIAlertAction actionWithTitle:@"OK"
                             style:UIAlertActionStyleDefault
                           handler:^(UIAlertAction * action) {
                               // ボタンタップ時の処理
                               retback = 1;
                              // c();
                           }];
    
    // コントローラにアクションを追加
    [ac addAction:cancelAction];
    [ac addAction:okAction];
    UIViewController *controller = UnityGetGLViewController();
    // アラート表示処理
    [controller presentViewController:ac animated:YES completion:nil];
    while (retback == -1) {
        [[NSRunLoop currentRunLoop]
         runUntilDate:[NSDate dateWithTimeIntervalSinceNow:0.5f]]; //0.5秒
    }
   return retback;
}
}
